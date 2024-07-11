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

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserRequest request)
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

    }
}