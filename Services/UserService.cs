using System.Security.Cryptography;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.AppDataContext;
using SocialMediaAPI.Contracts;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mapping;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Services
{
    public class UserService : IUserServices
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

        public async Task CreateUserAsync(UserRequest request)
        {
            try
            {
                // Map User request obj to User obj
                var user = _mapper.Map<User>(request);
                user.CreatedAt = DateTime.Now;
                await _userDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occur when creating user");
                throw new Exception("An error occur when creating");
            }
        }

        public Task DelteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userDbContext.Users.ToListAsync();

                if (users == null)
                {
                    return [];
                }

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occur when retrieving users");
                throw new Exception("An error occur when retrieving users");
            }
        }

        public Task<User> GetUserByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpateUserAsync(Guid id, UserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}