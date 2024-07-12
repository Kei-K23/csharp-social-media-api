using AutoMapper;
using SocialMediaAPI.Contracts;

namespace SocialMediaAPI.Mapping
{
    public class PostAutoMapper : Profile
    {
        public PostAutoMapper()
        {
            CreateMap<PostRequest, Models.Post>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<Models.Post, PostResponse>();
        }
    }
}