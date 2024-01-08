using System.Security.Claims;

namespace Bonyan.Bnb.Identity.Jwt;

public interface IJwtService
{
    public JwtResult GenerateTokenAsync(List<Claim> claims, CancellationToken cancellationToken = default);
}