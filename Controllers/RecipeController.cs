using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiScrabble.Entities;
using ApiScrabble.Context;
using ApiScrabble.DTO;

namespace ApiScrabble.Controllers;

[ApiController]
[Route("/api/recipes")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public RecipeController(ILogger<RecipeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetRecipes")]
    public async Task<ActionResult> GetRecipes()
    {
        // return list of recipes
        return Ok(await _dbContext.recipes.ToListAsync());
    }

    [HttpGet("{id}", Name = "GetRecipe")]
    public async Task<ActionResult> GetRecipe([FromRoute] int id)
    {
        // return recipe by id
        Recipe? recipe = await _dbContext.recipes.FindAsync(id);

        // return BadRequest if recipe not found else return recipe
        return recipe == null ? BadRequest() : Ok(recipe);
    }

    [HttpGet("user/{user_id}", Name = "GetUserRecipes")]
    public async Task<ActionResult> GetUserRecipes([FromRoute] int user_id)
    {
        // find user by id
        User? user = await _dbContext.users.FindAsync(user_id);

        // return BadRequest if user not found
        if (user == null) return BadRequest();

        // return list of recipes by user id
        return Ok(await _dbContext.recipes.Where(r => r.user_id == user_id).ToListAsync());
    }

    [HttpGet("{id}/user/{user_id}", Name = "GetUserRecipe")]
    public async Task<ActionResult> GetUserRecipe([FromRoute] int id, [FromRoute] int user_id)
    {
        // find recipe by id
        Recipe? recipe = await _dbContext.recipes.FindAsync(id);

        // return BadRequest if recipe not found or if user id is not the same as the recipe user id
        if (recipe == null || user_id != recipe.user_id) return BadRequest();

        // return recipe
        return Ok(recipe);
    }

    [HttpPost("user/{user_id}", Name = "CreateUserRecipe")]
    public async Task<ActionResult> Create([FromRoute] int user_id, [FromBody] UpsertRecipeRequest _UpsertRecipeRequest)
    {
        // find user by id
        User? user = await _dbContext.users.FindAsync(user_id);

        // return BadRequest if user not found
        if (user == null) return BadRequest();

        // create recipe object from request
        Recipe recipe = new Recipe()
        {
            name = _UpsertRecipeRequest.name,
            nb_people = _UpsertRecipeRequest.nb_people,
            preparation_time = _UpsertRecipeRequest.preparation_time,
            description = _UpsertRecipeRequest.description,
            user_id = user_id
        };

        // add recipe to database
        await _dbContext.recipes.AddAsync(recipe);
        await _dbContext.SaveChangesAsync();

        // return recipe created
        return CreatedAtAction(nameof(GetUserRecipe), new { id = recipe.id, user_id = recipe.user_id }, recipe);
    }

    [HttpPatch("{id}/user/{user_id}", Name = "UpdateUserRecipe")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromRoute] int user_id, [FromBody] UpsertRecipeRequest _UpsertRecipeRequest)
    {
        // find recipe by id
        Recipe? recipe = await _dbContext.recipes.FindAsync(id);

        // return BadRequest if recipe not found or if user id is not the same as the recipe user id
        if (recipe == null || user_id != recipe.user_id) return BadRequest();

        // update recipe object from request
        recipe.name = _UpsertRecipeRequest.name;
        recipe.nb_people = _UpsertRecipeRequest.nb_people;
        recipe.preparation_time = _UpsertRecipeRequest.preparation_time;
        recipe.description = _UpsertRecipeRequest.description;

        // update recipe in database
        _dbContext.recipes.Update(recipe);
        await _dbContext.SaveChangesAsync();

        // return recipe updated
        return CreatedAtAction(nameof(GetUserRecipe), new { id = recipe.id, user_id = recipe.user_id }, recipe);
    }

    [HttpDelete("{id}/user/{user_id}", Name = "DeleteUserRecipe")]
    public async Task<ActionResult> Delete([FromRoute] int id, [FromRoute] int user_id)
    {
        // find recipe by id
        Recipe? recipe = await _dbContext.recipes.FindAsync(id);

        // return BadRequest if recipe not found or if user id is not the same as the recipe user id
        if (recipe == null || user_id != recipe.user_id) return BadRequest();

        // delete recipe from database
        _dbContext.recipes.Remove(recipe);
        await _dbContext.SaveChangesAsync();

        // return success message
        return Ok("Recipe of User deleted");
    }
}
