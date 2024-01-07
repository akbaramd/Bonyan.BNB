using Bonyan.BNB.DDD.Application;
using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.Example.Application;

public class AppService : ApplicationService
{
    public AppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}