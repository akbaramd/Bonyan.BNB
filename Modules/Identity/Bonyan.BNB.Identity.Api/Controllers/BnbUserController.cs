using Bonyan.BNB.AspNetCore.Mvc;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;

namespace Bonyan.BNB.Identity.Api.Controllers;

public abstract class BnbUserController(IUserAppService service)
    : BnbCrudController<IUserAppService, UserDto, UserDto, Guid, PagedAndSortedResultRequestDto, UserCreateDto,
        UserUpdateDto>(service);