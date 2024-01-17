using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace TrustPassAPI.Controllers;

// Controller action return types in ASP.NET Core web API:
// https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-8.0

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ICollection<User>>> GetUsers()
    {
        try
        {
            var users = await userService.GetUsersAsync();
            return users.Count > 0 ? Ok(users) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:long}", Name = "GetUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> GetUser([FromRoute] long id)
    {
        try
        {
            var user = await userService.GetUserAsync(id);
            return user != null ? Ok(user) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    // [HttpGet("mongo/{id:long}", Name = "GetMongoUser")]
    // public async Task<MongoUser?> GetMongoUser([FromRoute] long id)
    // {
    //     Console.WriteLine($"GetMongoUser({id})");
    //     return await _userService.GetMongoUserAsync(id);
    // }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        try
        {
            var createdUser = await userService.CreateUserAsync(user);
            return CreatedAtRoute(nameof(GetUser), new {id = createdUser!.Id}, createdUser);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    // [HttpPost("mongo")]
    // public async Task<MongoUser?> CreateMongoUser([FromBody] MongoUser user)
    // {
    //     Console.WriteLine($"CreateMongoUser({user})");
    //     return await _userService.CreateMongoUserAsync(user);
    //     return null;
    // }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
    {
        try
        {
            var updatedUser = await userService.UpdateUserAsync(user);
            return Ok(updatedUser);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteUser([FromRoute] long id)
    {
        try
        {
            await userService.DeleteUserAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}