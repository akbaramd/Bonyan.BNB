using AutoMapper;
using Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;
using Bonyan.BNB.Identity.Domain.Roles;

namespace Bonyan.BNB.Identity.Application.Contracts.Roles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<Role, RoleUpdateDto>().ReverseMap();
        CreateMap<Role, RoleCreateDto>().ReverseMap();
    }
}