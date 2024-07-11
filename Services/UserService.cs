using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.AppDataContext;
using SocialMediaAPI.Contracts;
using SocialMediaAPI.Interfaces;

namespace SocialMediaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;

        public UserService(
            ILogger<UserService> logger,
            UserDbContext userDbContext,
            IMapper userAutoMapper
        )
        {
            _logger = logger;
            _mapper = userAutoMapper;
            _userDbContext = userDbContext;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            // Check if user exists or not
            var user = await _userDbContext.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with id {id} not found");

            // Delete the user from the database context if exists
            _userDbContext.Users.Remove(user);
            await _userDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userDbContext.Users.ToListAsync();
                var userResponses = _mapper.Map<IEnumerable<UserResponse>>(users);

                return userResponses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occur when retrieving users");
                throw new Exception("An error occur when retrieving users");
            }
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid id)
        {
            // Check if user exists or not
            var user = await _userDbContext.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with id {id} not found");

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> UpdateUserAsync(Guid id, UserRequest request)
        {
            // Check if user exists or not
            var user = await _userDbContext.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with id {id} not found");
            try
            {
                // If request have value, then update
                if (request.Username != null)
                {
                    user.Username = request.Username;
                }
                if (request.Email != null)
                {
                    user.Email = request.Email;
                }
                if (request.Password != null)
                {
                    user.Password = request.Password;
                }
                if (request.Bio != null)
                {
                    user.Bio = request.Bio;
                }
                if (request.ProfilePicture != null)
                {
                    user.ProfilePicture = request.ProfilePicture;
                }

                user.UpdatedAt = DateTime.Now;
                // Save the changes
                await _userDbContext.SaveChangesAsync();

                return _mapper.Map<UserResponse>(user);
            }
            catch (Exception)
            {
                throw new Exception("An error occur when updating users");
            }

        }
    }
}