using Bonyan.Bnb.Attributes;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.EntityFrameworkCore;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Infrastructure.EntityFrameworkCore;

[DependsOnModules(
    typeof(BnbIdentityEntityFrameworkCoreModule),
    typeof(DomainModule)
)]
public class EntityFrameworkCoreModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddBnbIdentityDbContext<AppDbContext>(c =>
        {
            var configuration = context.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            c.UseSqlServer<AppDbContext>(configuration.GetConnectionString("DefaultConnection"));
        });

        // context.Services.AddDefaultRepository(typeof(Product),typeof(ProductRepository));
        base.ConfigureServices(context);
    }
}