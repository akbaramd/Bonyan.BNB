using Bonyan.Bnb.Modularity;
using Bonyan.Bnb.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.ObjectMapping;

public class BnbObjectMappingModule : BnbModule
{
    public override void PreConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.OnExposing(onServiceExposingContext =>
        {
                //Register types for IObjectMapper<TSource, TDestination> if implements
                onServiceExposingContext.ExposedTypes.AddRange(
                ReflectionHelper.GetImplementedGenericTypes(
                    onServiceExposingContext.ImplementationType,
                    typeof(IObjectMapper<,>)
                )
            );
        });
    }

    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddTransient(
            typeof(IObjectMapper<>),
            typeof(DefaultObjectMapper<>)
        );
    }
}
