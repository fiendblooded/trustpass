using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace TrustPassAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IUserService _userService;
    
    public UserController(ILogger<WeatherForecastController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    [HttpGet(Name = "GetUser")]
    [Route("{id:long}")]
    public async Task<User> Get([FromRoute] long id)
    {
        return await _userService.GetUserAsync(id);
    }
}