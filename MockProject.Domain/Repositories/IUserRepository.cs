using MockProject.Domain.Entities;

namespace MockProject.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByUsernamePasswordAsync(string username, string password);
        Task<int> CreateUserAsync(string email, string username, string password);
        Task<int> UpdateUserAsync(Guid id, string email);
        Task<int> DeleteUserAsync(Guid id);
    }
}
