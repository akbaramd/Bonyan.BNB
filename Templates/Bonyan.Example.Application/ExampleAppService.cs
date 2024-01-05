using Bonyan.BNB.DDD.Application;
using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.Example.Application;

public class ExampleAppService : ApplicationService
{
    public ExampleAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}