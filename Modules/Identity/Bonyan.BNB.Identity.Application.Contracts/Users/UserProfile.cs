using AutoMapper;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Application.Contracts.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
    }
}