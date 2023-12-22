using Contracts;
using Entities;

namespace EFCData;

public class UserDao : IUserService
{
    private readonly TrustPassDbContext _context;
    
    public UserDao(TrustPassDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserAsync(long id)
    {
        Console.WriteLine($"get-id: {id}");
        return await _context.Users!.FindAsync(id);
    }

    public async Task<User?> CreateUserAsync(User user)
    {
        Console.WriteLine($"user: {user}");
        await _context.Users!.AddAsync(user);
        await _context.SaveChangesAsync();
        return await _context.Users!.FindAsync(user.id);
    }

    public Task<User> UpdateUserAsync(User user)
    {
        Console.WriteLine($"update-user: {user}");
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(string id)
    {
        Console.WriteLine($"delete-id: {id}");
        throw new NotImplementedException();
    }
}