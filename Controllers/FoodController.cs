using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiScrabble.Entities;
using ApiScrabble.Context;
using ApiScrabble.DTO;

namespace ApiScrabble.Controllers;

[ApiController]
[Route("/api/foods")]

public class FoodController : ControllerBase
{
    private readonly ILogger<FoodController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public FoodController(ILogger<FoodController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetFoods")]
    public async Task<ActionResult> GetFoods()
    {
        // return list of foods
        return Ok(await _dbContext.foods.ToListAsync());
    }

    [HttpGet("{id}", Name = "GetFood")]
    public async Task<ActionResult> GetFood([FromRoute] int id)
    {
        // find food by id
        Food? food = await _dbContext.foods.FindAsync(id);

        // return BadRequest if food not found else return food
        return food == null ? BadRequest() : Ok(food);
    }

    [HttpPost(Name = "CreateFood")]
    public async Task<ActionResult> Create([FromBody] UpsertFoodRequest _UpsertFoodRequest)
    {
        // create food object from request
        Food food = new Food()
        {
            name = _UpsertFoodRequest.name,
            description = _UpsertFoodRequest.description
        };

        // add food to database
        await _dbContext.foods.AddAsync(food);
        await _dbContext.SaveChangesAsync();

        // return food created
        return CreatedAtAction(nameof(GetFood), new { id = food.id }, food);
    }

    [HttpPatch("{id}", Name = "UpdateFood")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpsertFoodRequest _UpsertFoodRequest)
    {
        // find food by id
        Food? food = await _dbContext.foods.FindAsync(id);

        // return BadRequest if food not found else return food
        if (food == null) return BadRequest();

        // update food object from request
        food.name = _UpsertFoodRequest.name;
        food.description = _UpsertFoodRequest.description;

        // update food in database
        _dbContext.foods.Update(food);
        await _dbContext.SaveChangesAsync();

        // return food updated
        return CreatedAtAction(nameof(GetFood), new { id = food.id }, food);
    }

    [HttpDelete("{id}", Name = "DeleteFood")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        // find food by id
        Food? food = await _dbContext.foods.FindAsync(id);

        // return BadRequest if food not found else return food
        if (food == null) return BadRequest();

        // delete food from database
        _dbContext.foods.Remove(food);
        await _dbContext.SaveChangesAsync();

        // return success message
        return Ok("Food deleted successfully");
    }
}