using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using MongoFramework.Linq;

namespace EFCData;

public class UserDao(PostgresDbContext context, MongoContext mongoContext) : IUserService
{
    public async Task<ICollection<User>> GetUsersAsync()
    {
        Console.WriteLine("get-all");
        return await EntityFrameworkQueryableExtensions.ToListAsync(context.Users!);
    }
    
    public async Task<User?> GetUserAsync(long id)
    {
        Console.WriteLine($"get-id: {id}");
        return await context.Users!.FindAsync(id);
    }
    public async Task<MongoUser?> GetMongoUserAsync(long id)
    {
        Console.WriteLine($"get-id: {id}");
        return await QueryableAsyncExtensions.FirstOrDefaultAsync(mongoContext.Users!, u => u.Id == id);
    }

    public async Task<User?> CreateUserAsync(User user)
    {
        Console.WriteLine($"user: {user}");
        await context.Users!.AddAsync(user);
        await context.SaveChangesAsync();
        return await context.Users!.FindAsync(user.Id);
    }
    public async Task<MongoUser> CreateMongoUserAsync(MongoUser user)
    {
        Console.WriteLine($"user: {user}");
        mongoContext.Users!.Add(user);
        await mongoContext.SaveChangesAsync();
        return await QueryableAsyncExtensions.FirstOrDefaultAsync(mongoContext.Users!, u => u.Id == user.Id);
    }

    public async Task<User?> UpdateUserAsync(User user)
    {
        Console.WriteLine($"update-user: {user}");
        context.Users!.Update(user);
        await context.SaveChangesAsync();
        return await context.Users!.FindAsync(user.Id);
    }

    public async Task DeleteUserAsync(long id)
    {
        Console.WriteLine($"delete-id: {id}");
        //LINQ to remove by id
        var user = await context.Users!.FindAsync(id);
        if (user != null)
            context.Users!.Remove(user);
        await context.SaveChangesAsync();
    }
}