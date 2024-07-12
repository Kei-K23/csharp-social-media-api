using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(10000, MinimumLength = 3)]
        [Required]
        public string? Content { get; set; }
        [StringLength(10000, MinimumLength = 3)]
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}