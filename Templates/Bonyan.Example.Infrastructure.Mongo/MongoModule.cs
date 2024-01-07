using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.Modularity;
using Bonyan.BNB.MongoDb;
using Bonyan.Example.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Infrastructure.Mongo;

[DependsOnModules(
    typeof(BnbMongoModule),
    typeof(DomainModule)
    )]
public class MongoModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddMongoDb(c =>
        {
            c.Uri = "mongodb://localhost:27017/";
            c.Database = "ExampleDB";
        });

        // context.Services.AddDefaultRepository(typeof(Product),typeof(ProductRepository));
        base.ConfigureServices(context);
    }
}