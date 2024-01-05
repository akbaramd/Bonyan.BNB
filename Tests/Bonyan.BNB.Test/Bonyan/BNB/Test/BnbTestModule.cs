using Bonyan.Bnb.Modularity;
using Bonyan.BNB.Test.Fake;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.Test;

public class BnbTestModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddSingleton<ITestCounter,TestCounter>();
        base.ConfigureServices(context);
    }
}