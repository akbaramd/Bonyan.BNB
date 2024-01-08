using System.Security.Claims;
using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Bnb.Identity;
using Bonyan.BNB.Identity.Application.Contracts.Jwt;
using Bonyan.BNB.Identity.Application.Contracts.Jwt.Dtos;
using Bonyan.BNB.Identity.Domain.DomainServices;
using Bonyan.BNB.Identity.Domain.Users;
using Bonyan.Bnb.Identity.Jwt;

namespace Bonyan.BNB.Identity.Application.Jwt;

public class IdentityJwtAppService : ApplicationService,IIdentityJwtAppService
{
    public IdentityJwtAppService( IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }

    private IdentityUserManager UserManager => LazyServiceProvider.LazyGetRequiredService<IdentityUserManager>();
    private IJwtService JwtService => LazyServiceProvider.LazyGetRequiredService<IJwtService>();
    
    public async Task<AuthenticationJwtDto> GenerateToken(AuthenticationJwtLoginDto loginDto)
    {
        var checkUserExists = await UserManager.ExistByUserNameAsync(loginDto.UserName);

        if (checkUserExists is false)
        {
            throw new Exception("user not found");
        }

        var user = await UserManager.GetByUserNameAsync(loginDto.UserName);
      
        var validatePassword = await UserManager.ComparePassword(user,loginDto.Password);
        if (validatePassword is false)
        {
            throw new Exception("password is incorrect");
        }
        
        user.GenerateRefreshToken();
        await UserManager.UpdateAsync(user);
        
        var claims = new List<Claim>() {};
        claims.Add(new Claim(ClaimTypes.Sid,user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.NameIdentifier,user.UserName.ToString()));
        claims.Add(new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"));
        var token = JwtService.GenerateTokenAsync(claims);

        return new AuthenticationJwtDto()
        {
            AccessToken =token.AccessToken,
            RefreshToken = user.RefreshToken,
            ExpireAt = token.ExpiredAt
        };
    }


    public async Task<AuthenticationJwtDto> RefreshToken(AuthenticationJwtRefreshTokenDto dto)
    {
        

        var user = await UserManager.FindByRefreshTokenAsync(dto.RefreshToken);
      
       
        if (user is null)
        {
            throw new Exception("authentication Failed");
        }
        
        user.GenerateRefreshToken();
        await UserManager.UpdateAsync(user);
        
        var claims = new List<Claim>() {};
        claims.Add(new Claim(ClaimTypes.Sid,user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.NameIdentifier,user.UserName.ToString()));
        claims.Add(new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"));
        var token = JwtService.GenerateTokenAsync(claims);

        return new AuthenticationJwtDto()
        {
            AccessToken =token.AccessToken,
            RefreshToken = user.RefreshToken,
            ExpireAt = token.ExpiredAt
        };
    }
}