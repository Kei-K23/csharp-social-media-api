namespace SocialMediaAPI.Contracts
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}