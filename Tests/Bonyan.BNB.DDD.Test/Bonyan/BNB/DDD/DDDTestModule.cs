using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.DDD.Domain;
using Bonyan.Bnb.Modularity;

namespace Bonyan.BNB.DDD;

[DependsOnModules(typeof(BnbDddDomainModule),typeof(BnbDddApplicationModule))]
public class DDDTestModule : BnbModule
{

}