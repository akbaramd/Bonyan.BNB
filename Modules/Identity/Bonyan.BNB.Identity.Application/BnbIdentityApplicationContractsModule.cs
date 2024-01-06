using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Users;
using Bonyan.Bnb.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.Identity.Application;

[DependsOnModules(typeof(BnbDddApplicationContractsModule))]
public class BnbIdentityApplicationModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddScoped<IUserAppService, UserAppService>();
        base.ConfigureServices(context);
    }
}