using AutoMapper;
using SocialMediaAPI.Contracts;

namespace SocialMediaAPI.Mapping
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserRequest, Models.User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<UserResponse, Models.User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<Models.User, UserResponse>();
        }
    }
}