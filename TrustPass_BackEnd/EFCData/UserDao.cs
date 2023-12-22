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
    
    public Task<User> GetUserAsync(long id)
    {
        //print id to console
        Console.WriteLine($"get-id: {id}");
        throw new NotImplementedException();
    }

    public Task<User> CreateUserAsync(User user)
    {
        Console.WriteLine($"user: {user}");
        throw new NotImplementedException();
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