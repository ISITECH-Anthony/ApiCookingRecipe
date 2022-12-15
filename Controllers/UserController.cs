using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiScrabble.Entities;
using ApiScrabble.Context;
using ApiScrabble.DTO;

namespace ApiScrabble.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public UserController(ILogger<UserController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult> GetUsers()
    {
        // return list of users
        return Ok(await _dbContext.users.ToListAsync());
    }

    [HttpGet("{id}", Name = "GetUser")]
    public async Task<ActionResult> GetUser([FromRoute] int id)
    {
        // find user by id
        User? user = await _dbContext.users.FindAsync(id);

        // return BadRequest if user not found else return user
        return user == null ? BadRequest() : Ok(user);
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<ActionResult> Create([FromBody] UpsertUserRequest _UpsertUserRequest)
    {
        // create user object from request
        User user = new User()
        {
            firstname = _UpsertUserRequest.firstname,
            lastname = _UpsertUserRequest.lastname,
            username = _UpsertUserRequest.username,
            email = _UpsertUserRequest.email,
            password = _UpsertUserRequest.password
        };

        // add user to database
        await _dbContext.users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        // return user created
        return CreatedAtAction(nameof(GetUser), new { id = user.id }, user);
    }

    [HttpPatch("{id}", Name = "UpdateUser")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpsertUserRequest _UpsertUserRequest)
    {
        // find user by id
        User? user = await _dbContext.users.FindAsync(id);

        // return BadRequest if user not found
        if (user == null) return BadRequest();

        // update user object from request
        user.firstname = _UpsertUserRequest.firstname;
        user.lastname = _UpsertUserRequest.lastname;
        user.username = _UpsertUserRequest.username;
        user.email = _UpsertUserRequest.email;
        user.password = _UpsertUserRequest.password;

        // update user in database
        _dbContext.users.Update(user);
        await _dbContext.SaveChangesAsync();

        // return user updated
        return Ok(CreatedAtAction(nameof(GetUser), new { id = user.id }, user));
    }

    [HttpDelete("{id}", Name = "DeleteUser")]
    public async Task<ActionResult> Delete(int id)
    {
        // find user by id
        User? user = await _dbContext.users.FindAsync(id);

        // return BadRequest if user not found
        if (user == null) return BadRequest();

        // delete user from database
        _dbContext.users.Remove(user);
        await _dbContext.SaveChangesAsync();

        // return success message
        return Ok("User deleted");
    }
}
