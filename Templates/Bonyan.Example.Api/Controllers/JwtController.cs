using Bonyan.BNB.Identity.Api.Controllers;
using Bonyan.BNB.Identity.Application.Contracts.Jwt;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bonyan.Example.Api.Controllers;

[Route("/api/jwt")]

public class JwtController(IIdentityJwtAppService service) : BnbJwtController(service);