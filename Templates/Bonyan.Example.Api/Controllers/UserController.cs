using Bonyan.BNB.Identity.Api.Controllers;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bonyan.Example.Api.Controllers;

[Route("/api/user")]

public class UserController(IUserAppService service) : BnbUserController(service);