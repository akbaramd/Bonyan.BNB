using Bonyan.BNB.AspNetCore.Mvc;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.Identity.Application.Contracts.Roles;
using Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;

namespace Bonyan.BNB.Identity.Api.Controllers;

public abstract class BnbRoleController(IRoleAppService service)
    : BnbCrudController<IRoleAppService, RoleDto, RoleDto, Guid, PagedAndSortedResultRequestDto, RoleCreateDto,
        RoleUpdateDto>(service);