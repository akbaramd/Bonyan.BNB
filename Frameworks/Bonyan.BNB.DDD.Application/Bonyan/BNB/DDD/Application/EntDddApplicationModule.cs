using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Domain;
using Bonyan.Bnb.Modularity;
using Bonyan.BNB.ObjectMapping;

namespace Bonyan.BNB.DDD.Application;

[
    DependsOnModules(
        typeof(BnbDddDomainModule),
        typeof(BnbObjectMappingModule),
        typeof(BnbDddApplicationContractsModule))]
public class BnbDddApplicationModule : BnbModule
{
}