using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Application;
using Bonyan.Example.Infrastructure.Mongo;

namespace Bonyan.Example.Api;

[DependsOnModules(
    typeof(BonyanExampleApplicationModule),
    typeof(BonyanExampleMongoModule))]
public class BonyanExampleApiModule : BnbModule
{
    
}