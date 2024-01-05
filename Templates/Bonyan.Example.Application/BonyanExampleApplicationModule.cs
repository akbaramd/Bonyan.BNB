using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Application.Contracts;
using Bonyan.Example.Domain;

namespace Bonyan.Example.Application;

[DependsOnModules(
    typeof(BonyanExampleDomainModule),
    typeof(BonyanExampleApplicationContractsModule))]
public class BonyanExampleApplicationModule : BnbModule
{
    
}