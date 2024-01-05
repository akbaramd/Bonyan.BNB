using Bonyan.BNB.DDD.Application.Services;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.ObjectMapping;

namespace Bonyan.BNB.DDD.Application;

public class ApplicationService : IApplicationService,
    ITransientDependency
{
    public ApplicationService(IBnbLazyServiceProvider lazyServiceProvider)
    {
        LazyServiceProvider = lazyServiceProvider;
    }

    public IBnbLazyServiceProvider LazyServiceProvider { get; set; } 
    public IObjectMapper Mapper => LazyServiceProvider.LazyGetRequiredService<IObjectMapper>();
 

}