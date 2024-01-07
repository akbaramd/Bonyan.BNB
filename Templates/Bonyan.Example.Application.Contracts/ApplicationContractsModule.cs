using Bonyan.Bnb.Attributes;
using Bonyan.BNB.AutoMapper;
using Bonyan.BNB.Identity.Application.Contracts;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Application.Contracts;

[DependsOnModules(
    typeof(BnbIdentityApplicationContractsModule)
    ,typeof(DomainSharedModule))]
public class ApplicationContractsModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ApplicationContractsModule>();

        Configure<BnbAutoMapperOptions>(options =>
        {
            // options.AddProfile<ProductMapper>(true);
        });
        base.ConfigureServices(context);
    }
}