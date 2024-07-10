using SocialMediaAPI.Contracts;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserRequest request);
        Task<UserResponse> UpdateUserAsync(Guid id, UserRequest request);
        Task DeleteUserAsync(Guid id);
    }
}