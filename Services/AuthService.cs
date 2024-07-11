using AutoMapper;
using SocialMediaAPI.AppDataContext;
using SocialMediaAPI.Contracts;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Services
{
    public class AuthService : IAuthService
    {

        private readonly ILogger<AuthService> _logger;
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;

        public AuthService(
            ILogger<AuthService> logger,
            UserDbContext userDbContext,
            IMapper userAutoMapper
        )
        {
            _logger = logger;
            _mapper = userAutoMapper;
            _userDbContext = userDbContext;
        }

        public Task UserLoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> UserRegisterAsync(UserRequest request)
        {
            try
            {
                // Map User request obj to User obj
                var user = _mapper.Map<User>(request);
                // Hash the password
                user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password, 11);
                user.CreatedAt = DateTime.Now;

                // Add the user to the database context
                await _userDbContext.Users.AddAsync(user);
                await _userDbContext.SaveChangesAsync();

                // Map the saved User entity to UserResponse obj
                var userResponse = _mapper.Map<UserResponse>(user);

                return userResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occur when registering the user");
                throw new Exception("An error occur when registering the user");
            }
        }
    }
}