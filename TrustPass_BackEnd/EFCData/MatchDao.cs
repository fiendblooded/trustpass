using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCData;

public class MatchDao(PostgresDbContext context) : IMatchService
{

    public async Task<ICollection<Match>> GetMatchesAsync()
    {
        return await context.Matches!.ToListAsync();
    }

    public async Task<Match?> GetMatchAsync(long id)
    {
        return await context.Matches!.FindAsync(id);
    }

    public async Task<Match?> CreateMatchAsync(Match match)
    {
        await context.Matches!.AddAsync(match);
        await context.SaveChangesAsync();
        return await context.Matches!.FindAsync(match.Id);
    }

    public async Task<Match?> UpdateMatchAsync(Match match)
    {
        context.Matches!.Update(match);
        await context.SaveChangesAsync();
        return await context.Matches!.FindAsync(match.Id);
    }

    public async Task DeleteMatchAsync(long id)
    {
        var match = await context.Matches!.FindAsync(id);
        if (match != null)
            context.Matches!.Remove(match);
        await context.SaveChangesAsync();
    }

    public async Task<ICollection<Match>> GetUpcomingMatchesAsync()
    {
        //LINQ to get all matches where the 'when' is in the future
        return await context.Matches!.Where(x => x.When > DateTime.Now).ToListAsync();
    }

    public async Task<ICollection<Match>> GetPastMatchesAsync()
    {
        //LINQ to get all matches where the 'when' is in the past
        return await context.Matches!.Where(x => x.When < DateTime.Now).ToListAsync();
    }
}