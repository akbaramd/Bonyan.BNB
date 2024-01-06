using Bonyan.Bnb.Attributes;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain;
using Bonyan.Example.Domain.Aggregates.Products;
using Bonyan.Example.Infrastructure.EntityFrameworkCore.Repositories;
using Bonyan.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Infrastructure.EntityFrameworkCore;

[DependsOnModules(typeof(BonyanExampleDomainModule),typeof(BnbEntityFrameworkCoreModule))]
public class BonyanExampleEfCoreModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddBnbDbContext<AppDbContext>(c =>
        {
            c.UseSqlServer("");
        },opt=>{});

        context.Services.AddDefaultRepository(typeof(Product),typeof(ProductRepository));
        base.ConfigureServices(context);
    }
}