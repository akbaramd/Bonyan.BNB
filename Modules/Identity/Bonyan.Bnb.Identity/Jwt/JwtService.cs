using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bonyan.Bnb.Identity.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bonyan.Bnb.Identity.Jwt;

public class JwtService(IOptions<BnbIdentityJwtOptions> options) : IJwtService
{
    private readonly BnbIdentityJwtOptions _options = options.Value;

    public JwtResult GenerateTokenAsync(List<Claim> claims, CancellationToken cancellationToken)
    {
        var expireAt = DateTime.Now.AddMinutes(_options.ExpireMinutes);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var Sectoken = new JwtSecurityToken(
            issuer:_options.Issuer,
            audience:_options.Audience,
            expires: expireAt,
            signingCredentials: credentials);

        var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);

        return new JwtResult
        {
            AccessToken = token,
            ExpiredAt = expireAt
        };
    }
}