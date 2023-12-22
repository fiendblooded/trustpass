using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace TrustPassAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    
    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    
    [HttpGet]
    public async Task<IEnumerable<User>> GetUsers()
    {
        Console.WriteLine("GetUsers()");
        return await _userService.GetUsersAsync();
    }
    
    [HttpGet("{id:long}", Name = "GetUser")]
    public async Task<User?> GetUser([FromRoute] long id)
    {
        Console.WriteLine($"GetUser({id})");
        return await _userService.GetUserAsync(id);
    }

    [HttpGet("mongo/{id:long}", Name = "GetMongoUser")]
    public async Task<MongoUser?> GetMongoUser([FromRoute] long id)
    {
        Console.WriteLine($"GetMongoUser({id})");
        return await _userService.GetMongoUserAsync(id);
        return null;
    }

    [HttpPost]
    public async Task<User?> CreateUser([FromBody] User user)
    {
        Console.WriteLine($"CreateUser({user})");
        return await _userService.CreateUserAsync(user);
    }
    [HttpPost("mongo")]
    public async Task<MongoUser?> CreateMongoUser([FromBody] MongoUser user)
    {
        Console.WriteLine($"CreateMongoUser({user})");
        return await _userService.CreateMongoUserAsync(user);
        return null;
    }
    
    [HttpPut]
    public async Task<User?> UpdateUser([FromBody] User user)
    {
        Console.WriteLine($"UpdateUser({user})");
        return await _userService.UpdateUserAsync(user);
    }
    
    [HttpDelete("{id:long}")]
    public async Task DeleteUser([FromRoute] long id)
    {
        Console.WriteLine($"DeleteUser({id})");
        await _userService.DeleteUserAsync(id);
    }
}