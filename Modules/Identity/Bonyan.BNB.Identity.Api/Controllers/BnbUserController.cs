using Bonyan.BNB.AspNetCore.Mvc;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;

namespace Bonyan.BNB.Identity.Api.Controllers;

public abstract class BnbUserController(IIdentityUserAppService service)
    : BnbCrudController<IIdentityUserAppService, IdentityUserDto, IdentityUserDto, Guid, PagedAndSortedResultRequestDto,
        IdentityUserCreateDto,
        IdentityUserUpdateDto>(service)
{
     
}