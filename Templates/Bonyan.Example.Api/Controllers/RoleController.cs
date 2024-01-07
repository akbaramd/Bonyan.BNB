using Bonyan.BNB.Identity.Api.Controllers;
using Bonyan.BNB.Identity.Application.Contracts.Roles;
using Microsoft.AspNetCore.Mvc;

namespace Bonyan.Example.Api.Controllers;

[Route("/api/role")]

public class RoleController(IRoleAppService service) : BnbRoleController(service);