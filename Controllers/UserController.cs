using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Contracts;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userServices)
        {
            _userService = userServices;
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
                // Create and save user
                await _userService.CreateUserAsync(request);

                return StatusCode(202, new ApiResponse { message = "User created successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the  user", error = ex.Message });
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                // Create and save user
                var users = await _userService.GetAllUsersAsync();

                if (users == null || !users.Any())
                {
                    return StatusCode(200, new { message = "No user found" });

                }
                return StatusCode(200, new { message = "User created successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the  user", error = ex.Message });
            }

        }

    }
}