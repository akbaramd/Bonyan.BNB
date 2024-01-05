using Bonyan.Bnb;
using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Bnb.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Bonyan.BNB.Test.DependencyInjection;

public class AutoServiceRegistration_Tests
{
    [Fact]
    public async Task AutoServiceRegistration_Should_Not_Duplicate_Test_Async()
    {
        using (var application = await BnbApplicationFactory.CreateAsync<TestModule>())
        {
            //Act
            await application.InitializeAsync();

            //Assert
            var services = application.ServiceProvider.GetServices<TestService>().ToList();
            services.Count.ShouldBe(1);
        }
    }

    [Fact]
    public void AutoServiceRegistration_Should_Not_Duplicate_Test()
    {
        using (var application = BnbApplicationFactory.Create<TestModule>())
        {
            //Act
            application.Initialize();

            //Assert
            var services = application.ServiceProvider.GetServices<TestService>().ToList();
            services.Count.ShouldBe(1);
        }
    }
}

[DependsOnModules(typeof(TestDependedModule))]
public class TestModule : BnbModule
{

}

public class TestDependedModule : BnbModule
{

}

public class TestService : ITransientDependency
{

}
