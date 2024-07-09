using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Contracts
{
    // This DTO will be use for both Create and Update Request
    public class UserRequest
    {
        [StringLength(80, MinimumLength = 3)]
        [Required]
        public string? Username { get; set; }

        [StringLength(80, MinimumLength = 3)]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Required]
        public string? Password { get; set; }

        public string? ProfilePicture { get; set; }

        [StringLength(300, MinimumLength = 5)]
        public string? Bio { get; set; }
    }
}