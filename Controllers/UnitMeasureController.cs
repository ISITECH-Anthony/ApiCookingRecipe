using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiScrabble.Entities;
using ApiScrabble.Context;
using ApiScrabble.DTO;

namespace ApiScrabble.Controllers;

[ApiController]
[Route("/api/unit-measures")]

public class UnitMeasureController : ControllerBase
{
    private readonly ILogger<UnitMeasureController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public UnitMeasureController(ILogger<UnitMeasureController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetUnitMeasures")]
    public async Task<ActionResult> GetUnitMeasures()
    {
        // return list of unitMeasures
        return Ok(await _dbContext.unitMeasures.ToListAsync());
    }

    [HttpGet("{id}", Name = "GetUnitMeasure")]
    public async Task<ActionResult> GetUnitMeasure([FromRoute] int id)
    {
        // find unitMeasure by id
        UnitMeasure? unitMeasure = await _dbContext.unitMeasures.FindAsync(id);

        // return BadRequest if unitMeasure not found else return unitMeasure
        return unitMeasure == null ? BadRequest() : Ok(unitMeasure);
    }

    [HttpPost(Name = "CreateUnitMeasure")]
    public async Task<ActionResult> Create([FromBody] UpsertUnitMeasureRequest _UpsertUnitMeasureRequest)
    {
        // create unitMeasure object from request
        UnitMeasure unitMeasure = new UnitMeasure()
        {
            name = _UpsertUnitMeasureRequest.name,
            abreviation = _UpsertUnitMeasureRequest.abreviation
        };

        // add unitMeasure to database
        await _dbContext.unitMeasures.AddAsync(unitMeasure);
        await _dbContext.SaveChangesAsync();

        // return unitMeasure created
        return CreatedAtAction(nameof(GetUnitMeasure), new { id = unitMeasure.id }, unitMeasure);
    }

    [HttpPatch("{id}", Name = "UpdateUnitMeasure")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpsertUnitMeasureRequest _UpsertUnitMeasureRequest)
    {
        // find unitMeasure by id
        UnitMeasure? unitMeasure = await _dbContext.unitMeasures.FindAsync(id);

        // return BadRequest if unitMeasure not found else update unitMeasure
        if (unitMeasure == null) return BadRequest();

        // update unitMeasure object from request
        unitMeasure.name = _UpsertUnitMeasureRequest.name;
        unitMeasure.abreviation = _UpsertUnitMeasureRequest.abreviation;

        // update unitMeasure in database
        _dbContext.unitMeasures.Update(unitMeasure);
        await _dbContext.SaveChangesAsync();

        // return unitMeasure updated
        return CreatedAtAction(nameof(GetUnitMeasure), new { id = unitMeasure.id }, unitMeasure);
    }

    [HttpDelete("{id}", Name = "DeleteUnitMeasure")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        // find unitMeasure by id
        UnitMeasure? unitMeasure = await _dbContext.unitMeasures.FindAsync(id);

        // return BadRequest if unitMeasure not found else delete unitMeasure
        if (unitMeasure == null) return BadRequest();

        // delete unitMeasure from database
        _dbContext.unitMeasures.Remove(unitMeasure);
        await _dbContext.SaveChangesAsync();

        // return success message
        return Ok("UnitMeasure deleted successfully");
    }
}