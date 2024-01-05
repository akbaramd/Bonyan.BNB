using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Domain;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain.Shared;

namespace Bonyan.Example.Domain;

[DependsOnModules(typeof(BnbDddDomainModule),typeof(BonyanExampleDomainSharedModule))]
public class BonyanExampleDomainModule : BnbModule
{
    
}