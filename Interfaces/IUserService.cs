using SocialMediaAPI.Contracts;

namespace SocialMediaAPI.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(Guid id);
        Task<UserResponse> UpdateUserAsync(Guid id, UserRequest request);
        Task DeleteUserAsync(Guid id);
    }
}