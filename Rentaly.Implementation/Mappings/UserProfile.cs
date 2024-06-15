using AutoMapper;
using Rentaly.Application.DTOs.Users;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Mappings;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>()
           .ForMember(dest => dest.Password, opt => opt.ConvertUsing(new PasswordConverter()))
           .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => 2));

        CreateMap<User, UserProfileDto>()
           .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
    }
}
