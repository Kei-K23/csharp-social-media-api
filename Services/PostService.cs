using AutoMapper;
using SocialMediaAPI.AppDataContext;
using SocialMediaAPI.Contracts;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PostService(
            ILogger<PostService> logger,
            AppDbContext context,
            IMapper mapper
        )
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostResponse> CreatePostsAsync(PostRequest request)
        {
            try
            {
                var post = _mapper.Map<Post>(request);
                post.CreatedAt = DateTime.Now;

                await _context.AddAsync(post);
                await _context.SaveChangesAsync();

                var postResponse = _mapper.Map<PostResponse>(post);
                return postResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occur when creating new post");
                throw new Exception("An error occur when creating new post");
            }
        }

        public Task DeletePostAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostResponse>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> GetPostByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> UpdatePostAsync(PostRequest request, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}