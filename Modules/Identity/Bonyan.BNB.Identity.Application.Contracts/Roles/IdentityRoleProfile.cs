using AutoMapper;
using Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;
using Bonyan.BNB.Identity.Domain.Roles;

namespace Bonyan.BNB.Identity.Application.Contracts.Roles;

public class IdentityRoleProfile : Profile
{
    public IdentityRoleProfile()
    {
        CreateMap<IdentityRole, IdentityRoleDto>().ReverseMap();
        CreateMap<IdentityRole, IdentityRoleUpdateDto>().ReverseMap();
        CreateMap<IdentityRole, IdentityRoleCreateDto>().ReverseMap();
    }
}