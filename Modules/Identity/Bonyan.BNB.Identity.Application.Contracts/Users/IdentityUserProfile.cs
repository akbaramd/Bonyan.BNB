using AutoMapper;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Application.Contracts.Users;

public class IdentityUserProfile : Profile
{
    public IdentityUserProfile()
    {
        CreateMap<IdentityUser, IdentityUserDto>().ReverseMap();
        CreateMap<IdentityUser, IdentityUserCreateDto>().ReverseMap();
        CreateMap<IdentityUser, IdentityUserUpdateDto>().ReverseMap();
    }
}