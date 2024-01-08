using Bonyan.BNB.AspNetCore.Mvc;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.Identity.Application.Contracts.Jwt;
using Bonyan.BNB.Identity.Application.Contracts.Jwt.Dtos;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Bonyan.BNB.Identity.Api.Controllers;

public abstract class BnbJwtController( IIdentityJwtAppService identityJwtAppService)
    : ControllerBase
{

private readonly IIdentityJwtAppService _identityJwtAppService = identityJwtAppService;
    
    [HttpPost("generate")]
    public async Task<AuthenticationJwtDto> GenerateToken([FromBody] AuthenticationJwtLoginDto dto)
    {
        return await _identityJwtAppService.GenerateToken(dto);
    }
    [HttpPost("refresh-token")]
    public async Task<AuthenticationJwtDto> RefreshToken([FromBody] AuthenticationJwtRefreshTokenDto dto)
    {
        return await _identityJwtAppService.RefreshToken(dto);
    }
}
       