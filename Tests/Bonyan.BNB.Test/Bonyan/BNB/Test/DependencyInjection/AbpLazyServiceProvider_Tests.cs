using Bonyan.Bnb;
using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Bnb.Modularity;
using Bonyan.BNB.Test.Fake;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Bonyan.BNB.Test.DependencyInjection;

public class EntLazyServiceProvider_Tests
{
    [Fact]
    public void LazyServiceProvider_Should_Cache_Services()
    {
        using (var application = BnbApplicationFactory.Create<TestModule>())
        {
            application.Initialize();

            var lazyServiceProvider = application.ServiceProvider.GetRequiredService<IBnbLazyServiceProvider>();

            var transientTestService1 = lazyServiceProvider.LazyGetRequiredService<TransientTestService>();
            var transientTestService2 = lazyServiceProvider.LazyGetRequiredService<TransientTestService>();
            transientTestService1.ShouldBeSameAs(transientTestService2);

            var testCounter = application.ServiceProvider.GetRequiredService<ITestCounter>();
            testCounter.GetValue(nameof(TransientTestService)).ShouldBe(1);
        }
    }

    [DependsOnModules(typeof(BnbTestModule))]
    private class TestModule : BnbModule
    {
        public TestModule()
        {
            SkipAutoServiceRegistration = true;
        }

        public override void ConfigureServices(BnbServiceConfigurationContext context)
        {
            context.Services.AddType<TransientTestService>();
        }
    }

    private class TransientTestService : ITransientDependency
    {
        public TransientTestService(ITestCounter counter)
        {
            counter.Increment(nameof(TransientTestService));
        }
    }
}
