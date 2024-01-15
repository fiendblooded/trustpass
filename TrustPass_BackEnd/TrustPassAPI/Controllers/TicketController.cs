using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace TrustPassAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController(ITicketService ticketService) : ControllerBase
{

    [HttpGet]
    [Route("user/{id:long}")]
    public async Task<ICollection<Ticket>> GetTicketsByUserId([FromRoute] long userId)
    {
        Console.WriteLine($"GetTicketsByUserId({userId})");
        return await ticketService.GetTicketsByUserIdAsync(userId);
    }
    
    [HttpGet]
    [Route("match/{id:long}")]
    public async Task<ICollection<Ticket>> GetTicketsByMatchId([FromRoute] long matchId)
    {
        Console.WriteLine($"GetTicketsByMatchId({matchId})");
        return await ticketService.GetTicketsByMatchIdAsync(matchId);
    }
    
    [HttpGet("{id:long}", Name = "GetTicket")]
    public async Task<Ticket?> GetTicket([FromRoute] long id)
    {
        Console.WriteLine($"GetTicket({id})");
        return await ticketService.GetTicketAsync(id);
    }
    
    [HttpPost]
    public async Task<Ticket?> CreateTicket([FromBody] Ticket ticket)
    {
        //should be done in the database trigger?
        ticket.CreatedAt = DateTime.UtcNow;
        ticket.UpdatedAt = DateTime.UtcNow;
        Console.WriteLine($"CreateTicket({ticket})");
        return await ticketService.CreateTicketAsync(ticket);
    }
    
    [HttpPut]
    public async Task<Ticket?> UpdateTicket([FromBody] Ticket ticket)
    {
        ticket.UpdatedAt = DateTime.UtcNow;
        Console.WriteLine($"UpdateTicket({ticket})");
        return await ticketService.UpdateTicketAsync(ticket);
    }
    
    [HttpDelete("{id:long}")]
    public async Task DeleteTicket([FromRoute] long id)
    {
        Console.WriteLine($"DeleteTicket({id})");
        await ticketService.DeleteTicketAsync(id);
    }
}