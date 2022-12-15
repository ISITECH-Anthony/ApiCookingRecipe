using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiScrabble.Entities;
using ApiScrabble.Context;
using ApiScrabble.DTO;

namespace ApiScrabble.Controllers;

[ApiController]
[Route("/api/opinions")]

public class OpinionController : ControllerBase
{
    private readonly ILogger<OpinionController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public OpinionController(ILogger<OpinionController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetOpinions")]
    public async Task<ActionResult> GetOpinions()
    {
        // return list of opinions
        return Ok(await _dbContext.opinions.ToListAsync());
    }

    [HttpGet("{id}", Name = "GetOpinion")]
    public async Task<ActionResult> GetOpinion([FromRoute] int id)
    {
        // find opinion by id
        Opinion? opinion = await _dbContext.opinions.FindAsync(id);

        // return BadRequest if opinion not found else return opinion
        return opinion == null ? BadRequest() : Ok(opinion);
    }

    [HttpPost(Name = "CreateOpinion")]
    public async Task<ActionResult> Create([FromBody] CreateOpinionRequest _CreateOpinionRequest)
    {
        // find recipe by id
        Recipe? recipe = await _dbContext.recipes.FindAsync(_CreateOpinionRequest.recipe_id);

        // return BadRequest if recipe not found
        if (recipe == null) return BadRequest();

        // find user by id
        User? user = await _dbContext.users.FindAsync(_CreateOpinionRequest.user_id);

        // return BadRequest if user not found
        if (user == null) return BadRequest();

        // return BadRequest if user id is the same as the recipe user id
        if (recipe.user_id == user.id) return BadRequest();
        
        // create opinion object
        Opinion opinion = new Opinion()
        {
            grade = _CreateOpinionRequest.grade,
            comment = _CreateOpinionRequest.comment,
            recipe_id = _CreateOpinionRequest.recipe_id,
            user_id = _CreateOpinionRequest.user_id
        };

        // add opinion to database
        await _dbContext.opinions.AddAsync(opinion);
        await _dbContext.SaveChangesAsync();

        // return opinion created
        return CreatedAtAction(nameof(GetOpinion), new { id = opinion.id }, opinion);
    }

    [HttpPatch("{id}", Name = "UpdateOpinion")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateOpinionRequest _UpdateOpinionRequest)
    {
        // find opinion by id
        Opinion? opinion = await _dbContext.opinions.FindAsync(id);

        // return BadRequest if opinion not found
        if (opinion == null) return BadRequest();

        // update opinion object from request
        opinion.grade = _UpdateOpinionRequest.grade;
        opinion.comment = _UpdateOpinionRequest.comment;

        // update opinion in database
        _dbContext.opinions.Update(opinion);
        await _dbContext.SaveChangesAsync();

        // return opinion updated
        return CreatedAtAction(nameof(GetOpinion), new { id = opinion.id }, opinion);
    }

    [HttpDelete("{id}", Name = "DeleteOpinion")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        // find opinion by id
        Opinion? opinion = await _dbContext.opinions.FindAsync(id);

        // return BadRequest if opinion not found
        if (opinion == null) return BadRequest();

        // delete opinion from database
        _dbContext.opinions.Remove(opinion);
        await _dbContext.SaveChangesAsync();

        // return NoContent
        return NoContent();
    }
}