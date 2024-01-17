using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace TrustPassAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController(ITicketService ticketService) : ControllerBase
{
    
    [HttpGet]
    [Route("{userId:long}/{matchId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Ticket>> GetTicket([FromRoute] long userId, [FromRoute] long matchId)
    {
        try
        {
            var ticket = await ticketService.GetTicketAsync(userId, matchId);
            return ticket != null ? Ok(ticket) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("user/{userId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ICollection<Ticket>>> GetTicketsByUserId([FromRoute] long userId)
    {
        try
        {
            var tickets = await ticketService.GetTicketsByUserIdAsync(userId);
            return tickets.Count > 0 ? Ok(tickets) : NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("match/{matchId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ICollection<Ticket>>> GetTicketsByMatchId([FromRoute] long matchId)
    {
        try
        {
            var tickets = await ticketService.GetTicketsByMatchIdAsync(matchId);
            return tickets.Count > 0 ? Ok(tickets) : NotFound();
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
    public async Task<ActionResult<Ticket>> CreateTicket([FromBody] Ticket ticket)
    {
        try
        {
            var createdTicket = await ticketService.CreateTicketAsync(ticket);
            return CreatedAtAction(nameof(GetTicket), new {userId = createdTicket!.UserId, matchId = createdTicket.MatchId}, createdTicket);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Ticket>> UpdateTicket([FromBody] Ticket ticket)
    {
        try
        {
            var updatedTicket = await ticketService.UpdateTicketAsync(ticket);
            return updatedTicket != null ? Ok(updatedTicket) : NotFound();
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
    public async Task<ActionResult> DeleteTicket([FromRoute] long id)
    {
        try
        {
            await ticketService.DeleteTicketAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}