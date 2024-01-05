using AutoMapper;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.BNB.DDD.Application;

public class ApplicationService : IApplicationService,
    ITransientDependency
{

    public IBnbLazyServiceProvider LazyServiceProvider { get; set; } = default!;
    public IMapper Mapper => LazyServiceProvider.LazyGetRequiredService<IMapper>();
 

}