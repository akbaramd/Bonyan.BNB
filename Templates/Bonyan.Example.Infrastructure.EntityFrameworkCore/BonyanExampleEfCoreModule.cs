using Bonyan.Bnb.Attributes;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.EntityFrameworkCore;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain;
using Bonyan.Example.Domain.Aggregates.Products;
using Bonyan.Example.Infrastructure.EntityFrameworkCore.Repositories;
using Bonyan.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Infrastructure.EntityFrameworkCore;

[DependsOnModules(typeof(BonyanExampleDomainModule),typeof(BnbIdentityDomainEfCoreModule))]
public class BonyanExampleEfCoreModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddBnbIdentityDbContext<AppDbContext>(c =>
        {
            var configuration = context.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            c.UseSqlServer<AppDbContext>(configuration.GetConnectionString("DefaultConnection"));
        });

        context.Services.AddDefaultRepository(typeof(Product),typeof(ProductRepository));
        base.ConfigureServices(context);
    }
}