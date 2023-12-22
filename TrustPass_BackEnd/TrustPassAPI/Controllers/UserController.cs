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
    }
}