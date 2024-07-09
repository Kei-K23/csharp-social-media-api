namespace SocialMediaAPI.Models
{
    public class ApiResponse<T>
    {
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(string message)
        {
            Message = message;
        }
    }
}