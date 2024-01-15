using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace TrustPassAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController(IMatchService matchService) : ControllerBase
{
    
    [HttpGet]
    public async Task<ICollection<Match>> GetMatches()
    {
        Console.WriteLine("GetMatches()");
        return await matchService.GetMatchesAsync();
    }
    
    [HttpGet]
    [Route("upcoming")]
    public async Task<ICollection<Match>> GetUpcomingMatches()
    {
        Console.WriteLine("GetUpcomingMatches()");
        return await matchService.GetUpcomingMatchesAsync();
    }
    
    [HttpGet]
    [Route("past")]
    public async Task<ICollection<Match>> GetPastMatches()
    {
        Console.WriteLine("GetPastMatches()");
        return await matchService.GetPastMatchesAsync();
    }
    
    [HttpGet("{id:long}", Name = "GetMatch")]
    public async Task<Match?> GetMatch([FromRoute] long id)
    {
        Console.WriteLine($"GetMatch({id})");
        return await matchService.GetMatchAsync(id);
    }
    
    [HttpPost]
    public async Task<Match?> CreateMatch([FromBody] Match match)
    {
        //should be done in the database trigger?
        match.CreatedAt = DateTime.UtcNow;
        match.UpdatedAt = DateTime.UtcNow;
        Console.WriteLine($"CreateMatch({match})");
        return await matchService.CreateMatchAsync(match);
    }
    
    [HttpPut]
    public async Task<Match?> UpdateMatch([FromBody] Match match)
    {
        match.UpdatedAt = DateTime.UtcNow;
        Console.WriteLine($"UpdateMatch({match})");
        return await matchService.UpdateMatchAsync(match);
    }
    
    [HttpDelete("{id:long}")]
    public async Task DeleteMatch([FromRoute] long id)
    {
        Console.WriteLine($"DeleteMatch({id})");
        await matchService.DeleteMatchAsync(id);
    }
}