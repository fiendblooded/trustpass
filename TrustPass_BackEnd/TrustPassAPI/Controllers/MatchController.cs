using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace TrustPassAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController(IMatchService matchService) : ControllerBase
{
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ICollection<Match>>> GetMatches()
    {
        try
        {
            var matches = await matchService.GetMatchesAsync();
            return matches.Count > 0 ? Ok(matches) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("upcoming")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ICollection<Match>>> GetUpcomingMatches()
    {
        try
        {
            var matches = await matchService.GetUpcomingMatchesAsync();
            return matches.Count > 0 ? Ok(matches) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("past")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ICollection<Match>>> GetPastMatches()
    {
        try
        {
            var matches = await matchService.GetPastMatchesAsync();
            return matches.Count > 0 ? Ok(matches) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:long}", Name = "GetMatch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Match>> GetMatch([FromRoute] long id)
    {
        try
        {
            var match = await matchService.GetMatchAsync(id);
            return match != null ? Ok(match) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Match>> CreateMatch([FromBody] Match match)
    {
        try
        {
            Console.WriteLine(match);
            var createdMatch = await matchService.CreateMatchAsync(match);
            return CreatedAtRoute(nameof(GetMatch), new {id = createdMatch!.Id}, createdMatch);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Match>> UpdateMatch([FromBody] Match match)
    {
        try
        {
            var updatedMatch = await matchService.UpdateMatchAsync(match);
            return updatedMatch != null ? Ok(updatedMatch) : NotFound();
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
    public async Task<ActionResult> DeleteMatch([FromRoute] long id)
    {
        try
        {
            await matchService.DeleteMatchAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}