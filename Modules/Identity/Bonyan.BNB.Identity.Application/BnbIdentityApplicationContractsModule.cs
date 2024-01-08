using System.Text;
using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Application;
using Bonyan.Bnb.Identity;
using Bonyan.BNB.Identity.Application.Contracts.Jwt;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Jwt;
using Bonyan.BNB.Identity.Application.Users;
using Bonyan.Bnb.Identity.Jwt;
using Bonyan.Bnb.Identity.Options;
using Bonyan.Bnb.Modularity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bonyan.BNB.Identity.Application;

[DependsOnModules(typeof(BnbDddApplicationContractsModule))]
public class BnbIdentityApplicationModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddSingleton<IJwtService, JwtService>();
        
        context.Services.AddScoped<IIdentityUserAppService, IdentityUserAppService>();
        context.Services.AddScoped<IIdentityJwtAppService, IdentityJwtAppService>();
        
        
 
        
        base.ConfigureServices(context);
    }


    public override void PostConfigureServices(BnbServiceConfigurationContext context)
    {
        var jwtOptions = context.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetService<IOptions<BnbIdentityJwtOptions>>();

        if (jwtOptions is null)
        {
            throw new Exception($"option nor found . please use Configure<{nameof(BnbIdentityJwtOptions)}>(...) in module.");
        }
        
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Value.Issuer,
                    ValidAudience = jwtOptions.Value.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey))
                };
            });
        base.PostConfigureServices(context);
    }
    
    
    
}