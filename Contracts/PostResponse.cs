using SocialMediaAPI.Models;

namespace SocialMediaAPI.Contracts
{
    public class PostCreateRequest
    {

        public Guid Id { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}