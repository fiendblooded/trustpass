using Entities;

namespace Contracts;

public interface IMatchService
{
    public Task<ICollection<Match>> GetMatchesAsync();
    public Task<Match?> GetMatchAsync(long id);
    public Task<Match?> CreateMatchAsync(Match match);
    public Task<Match?> UpdateMatchAsync(Match match);
    public Task DeleteMatchAsync(long id);
    public Task<ICollection<Match>> GetUpcomingMatchesAsync();
    public Task<ICollection<Match>> GetPastMatchesAsync();
}