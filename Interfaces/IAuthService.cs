using SocialMediaAPI.Contracts;

namespace SocialMediaAPI.Interfaces
{
    public interface IAuthService
    {
        Task<UserResponse> UserRegisterAsync(UserRequest request);
        Task UserLoginAsync();
    }
}