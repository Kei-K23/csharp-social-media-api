using AutoMapper;
using SocialMediaAPI.Contracts.User;

namespace SocialMediaAPI.Mapping.User
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserRequest, Models.User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}