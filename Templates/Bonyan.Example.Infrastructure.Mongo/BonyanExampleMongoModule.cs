using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain;
using Bonyan.Example.Domain.Aggregates.Product;
using Bonyan.Example.Infrastructure.Mongo.Repositories;
using Bonyan.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Infrastructure.Mongo;

[DependsOnModules(typeof(BonyanExampleDomainModule))]
public class BonyanExampleMongoModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddMongoDb(c =>
        {
            c.Uri = "mongodb://localhost:27017/";
            c.Database = "ExampleDB";
        });

        context.Services.AddDefaultRepository(typeof(Product),typeof(ProductRepository));
        base.ConfigureServices(context);
    }
}