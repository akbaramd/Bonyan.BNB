using Bonyan.Bnb;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.Bnb.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Bonyan.BNB.DDD.Application;

public class AppServiceTests
{
    [Fact]
    public void Service_Should_Correct()
    {
        using (var application = BnbApplicationFactory.Create<DDDTestModule>())
        {
            
            application.Initialize();

            var lazyServiceProvider = application.ServiceProvider.GetRequiredService<IPersonService>();

            lazyServiceProvider.ShouldNotBeNull();
        }
    }

   
    public class PersonDto : EntityDto<Guid>
    {
       
    }
    public class Person : BnbEntity<Guid>
    {
        public Person()
        {
        }

        public Person(Guid id)
            : base(id)
        {
        }
    }

    interface IPersonService : ICrudAppService<PersonDto,Guid>,ITransientDependency
    {
        
    }
    public class PersonService : CrudAppService<Person,PersonDto,Guid>, IPersonService
    {
        public PersonService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
        {
        }
    }
   
}
