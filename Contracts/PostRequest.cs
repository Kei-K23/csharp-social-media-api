using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Contracts
{
    public class PostRequest
    {

        [StringLength(10000, MinimumLength = 3)]
        [Required]
        public string? Content { get; set; }
        [StringLength(10000, MinimumLength = 3)]
        public string? Image { get; set; }
    }
}