using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Contracts;
using SocialMediaAPI.Interfaces;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegisterAsync(UserRequest request)
        {
            // Check request body if valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Create and save register user
                var userResponse = await _authService.UserRegisterAsync(request);

                return StatusCode(201, new { message = "User register successful", data = userResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while registering the  user", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLoginAsync(UserLoginRequest request)
        {
            // Check request body if valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Create and save register user
                string token = await _authService.UserLoginAsync(request);

                return StatusCode(200, new { message = "User login successful", token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while registering the  user", error = ex.Message });
            }
        }

    }
}