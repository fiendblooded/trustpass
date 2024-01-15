using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCData;

public class TicketDao(PostgresDbContext context) : ITicketService
{

    public async Task<Ticket?> GetTicketAsync(long id)
    {
        return await context.Tickets!.FindAsync(id);
    }

    public async Task<ICollection<Ticket>> GetTicketsByUserIdAsync(long userId)
    {
        return await context.Tickets!.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<ICollection<Ticket>> GetTicketsByMatchIdAsync(long matchId)
    {
        return await context.Tickets!.Where(x => x.MatchId == matchId).ToListAsync();
    }

    public async Task<Ticket?> CreateTicketAsync(Ticket ticket)
    {
        await context.Tickets!.AddAsync(ticket);
        await context.SaveChangesAsync();
        //LINQ to find the ticket by composite key (UserId, MatchId)
        return await context.Tickets!.FirstOrDefaultAsync(x => x.UserId == ticket.UserId && x.MatchId == ticket.MatchId);
    }

    public async Task<Ticket?> UpdateTicketAsync(Ticket ticket)
    {
        context.Tickets!.Update(ticket);
        await context.SaveChangesAsync();
        return await context.Tickets!.FirstOrDefaultAsync(x => x.UserId == ticket.UserId && x.MatchId == ticket.MatchId);
    }

    public async Task DeleteTicketAsync(long id)
    {
        var ticket = await context.Tickets!.FindAsync(id);
        if (ticket != null)
            context.Tickets!.Remove(ticket);
        await context.SaveChangesAsync();
    }
}