using Bonyan.Bnb.Identity.Jwt;
using Bonyan.Bnb.Modularity;

namespace Bonyan.Bnb.Identity;


public class BnbIdentityModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddSingleton<IJwtService, IJwtService>();

        base.ConfigureServices(context);
    }
}