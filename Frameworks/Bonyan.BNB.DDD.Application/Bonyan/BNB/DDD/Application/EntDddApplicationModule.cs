using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Domain;
using Bonyan.Bnb.Modularity;

namespace Bonyan.BNB.DDD.Application;

[
    DependsOnModules(
        typeof(BnbDddDomainModule),
        typeof(BnbDddApplicationContractsModule))]
public class BnbDddApplicationModule : BnbModule
{
}