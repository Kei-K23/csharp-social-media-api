using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(80, MinimumLength = 3)]
        [Required]
        public string? Username { get; set; }

        [StringLength(80, MinimumLength = 3)]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(255, MinimumLength = 8)]
        [Required]
        public string? Password { get; set; }

        public string? ProfilePicture { get; set; }

        [StringLength(300, MinimumLength = 5)]
        public string? Bio { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        // Navigation property
        public ICollection<Post> Posts { get; set; }

    }
}