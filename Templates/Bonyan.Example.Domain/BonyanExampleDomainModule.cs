using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain.Shared;

namespace Bonyan.Example.Domain;

[DependsOnModules(typeof(BonyanExampleDomainSharedModule))]
public class BonyanExampleDomainModule : BnbModule
{
    
}