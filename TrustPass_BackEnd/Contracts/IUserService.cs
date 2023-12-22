using Entities;

namespace Contracts;

public interface IUserService
{
    public Task<User?> GetUserAsync(long id);
    public Task<User?> CreateUserAsync(User user);
    public Task<User> UpdateUserAsync(User user);
    public Task DeleteUserAsync(string id);
}