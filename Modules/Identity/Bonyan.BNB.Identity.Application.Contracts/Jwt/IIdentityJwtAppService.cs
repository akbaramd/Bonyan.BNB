using Bonyan.BNB.DDD.Application.Services;
using Bonyan.BNB.Identity.Application.Contracts.Jwt.Dtos;

namespace Bonyan.BNB.Identity.Application.Contracts.Jwt;

public interface IIdentityJwtAppService : IApplicationService
{
    public Task<AuthenticationJwtDto> GenerateToken(AuthenticationJwtLoginDto loginDto);
    public Task<AuthenticationJwtDto> RefreshToken(AuthenticationJwtRefreshTokenDto dto);
}