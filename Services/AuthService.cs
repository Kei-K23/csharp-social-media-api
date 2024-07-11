using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _config;

        public AuthService(
            ILogger<AuthService> logger,
            UserDbContext userDbContext,
            IMapper userAutoMapper,
            IConfiguration config
        )
        {
            _logger = logger;
            _mapper = userAutoMapper;
            _userDbContext = userDbContext;
            _config = config;
        }

        public async Task<string> UserLoginAsync(UserLoginRequest request)
        {
            // Get user by email and if not found throw not found exception
            var user = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email) ?? throw new UnauthorizedAccessException("User credentials are wrong!");

            // Verify password
            bool isAuthenticate = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password);

            // User is not authenticated, then throw exception
            if (!isAuthenticate)
            {
                throw new UnauthorizedAccessException("User credentials are wrong!");
            }

            // Generate JWT token
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(secToken);

            return token;
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