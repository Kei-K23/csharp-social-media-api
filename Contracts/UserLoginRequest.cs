using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Contracts
{
    // This DTO will be use for both Create and Update Request
    public class UserLoginRequest
    {
        [StringLength(80, MinimumLength = 3)]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Required]
        public string? Password { get; set; }

    }
}