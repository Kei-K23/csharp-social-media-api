using SocialMediaAPI.Contracts;

namespace SocialMediaAPI.Interfaces
{
    public interface IPostService
    {
        Task<PostResponse> CreatePostsAsync(PostRequest request);
        Task<IEnumerable<PostResponse>> GetAllPostsAsync();
        Task<PostResponse> GetPostByIdAsync(Guid id);
        Task<PostResponse> UpdatePostAsync(PostRequest request, Guid id);
        Task DeletePostAsync(Guid id);
    }
}