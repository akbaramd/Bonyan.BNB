using Bonyan.Bnb.Attributes;
using Bonyan.BNB.Identity.Api;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Application;
using Bonyan.Example.Infrastructure.EntityFrameworkCore;

namespace Bonyan.Example.Api;

[DependsOnModules(
    typeof(BnbIdentityApiModule),
    typeof(ApplicationModule),
    typeof(EntityFrameworkCoreModule)
)]
public class ApiModule : BnbModule
{
    
}