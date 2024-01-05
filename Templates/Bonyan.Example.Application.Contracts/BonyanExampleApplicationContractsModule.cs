using Bonyan.Bnb.Attributes;
using Bonyan.BNB.AutoMapper;
using Bonyan.BNB.DDD.Application;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Application.Contracts.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Application.Contracts;

[DependsOnModules(typeof(BnbDddApplicationContractsModule),typeof(BnbAutoMapperModule))]
public class BonyanExampleApplicationContractsModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<BonyanExampleApplicationContractsModule>();

        Configure<AbpAutoMapperOptions>(options => { options.AddProfile<ProductMapper>(true); });
        base.ConfigureServices(context);
    }
}