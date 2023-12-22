using Contracts;
using Entities;
using MongoFramework.Linq;

namespace EFCData;

public class UserDao : IUserService
{
    private readonly PostgresDbContext _context;
    private readonly MongoContext _mongoContext;
    
    public UserDao(PostgresDbContext context, MongoContext mongoContext)
    {
        _context = context;
        _mongoContext = mongoContext;
    }
    
    public async Task<User?> GetUserAsync(long id)
    {
        Console.WriteLine($"get-id: {id}");
        return await _context.Users!.FindAsync(id);
    }
    public async Task<MongoUser?> GetMongoUserAsync(long id)
    {
        Console.WriteLine($"get-id: {id}");
        return await _mongoContext.Users!.FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<User?> CreateUserAsync(User user)
    {
        Console.WriteLine($"user: {user}");
        await _context.Users!.AddAsync(user);
        await _context.SaveChangesAsync();
        return await _context.Users!.FindAsync(user.id);
    }
    public async Task<MongoUser> CreateMongoUserAsync(MongoUser user)
    {
        Console.WriteLine($"user: {user}");
        _mongoContext.Users!.Add(user);
        await _mongoContext.SaveChangesAsync();
        return await _mongoContext.Users!.FirstOrDefaultAsync(u => u.id == user.id);
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