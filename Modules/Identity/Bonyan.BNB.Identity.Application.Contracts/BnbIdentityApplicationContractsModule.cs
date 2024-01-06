using Bonyan.Bnb.Attributes;
using Bonyan.BNB.AutoMapper;
using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.Bnb.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.Identity.Application.Contracts;

[DependsOnModules(typeof(BnbAutoMapperModule),typeof(BnbDddApplicationContractsModule))]
public class BnbIdentityApplicationContractsModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<BnbIdentityApplicationContractsModule>();

        Configure<BnbAutoMapperOptions>(options =>
        {
            options.AddProfile<UserProfile>(true);
        });
        base.ConfigureServices(context);
    }
}