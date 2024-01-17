using Entities;

namespace Contracts;

public interface ITicketService
{
    public Task<Ticket?> GetTicketAsync(long userId, long matchId);
    public Task<ICollection<Ticket>> GetTicketsByUserIdAsync(long userId);
    public Task<ICollection<Ticket>> GetTicketsByMatchIdAsync(long matchId);
    public Task<Ticket?> CreateTicketAsync(Ticket ticket);
    public Task<Ticket?> UpdateTicketAsync(Ticket ticket);
    public Task DeleteTicketAsync(long id);
}