using Bonyan.BNB.DDD.Application.Services;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Bnb.Linq;
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
    public IAsyncQueryableExecuter AsyncQueryableExecuter => LazyServiceProvider.LazyGetRequiredService<IAsyncQueryableExecuter>();
    public IObjectMapper Mapper => LazyServiceProvider.LazyGetRequiredService<IObjectMapper>();
 

}