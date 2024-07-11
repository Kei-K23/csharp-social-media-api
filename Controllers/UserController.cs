using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Contracts;
using SocialMediaAPI.Interfaces;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userServices)
        {
            _userService = userServices;
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
                    return StatusCode(200, new { data = Array.Empty<object>() });
                }

                return StatusCode(200, new { data = users });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the  user", error = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                return StatusCode(200, new { data = user });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the  user", error = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UserRequest request)
        {
            try
            {
                var user = await _userService.UpdateUserAsync(id, request);

                return StatusCode(200, new { data = user });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the  user", error = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);

                return StatusCode(200, new { message = $"User with ID: {id} deleted successful" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the  user", error = ex.Message });
            }
        }

    }
}