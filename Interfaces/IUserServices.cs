using SocialMediaAPI.Contracts;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync();
        Task CreateUserAsync(UserRequest request);
        Task UpateUserAsync(Guid id, UserRequest request);
        Task DelteUserAsync(Guid id);
    }
}