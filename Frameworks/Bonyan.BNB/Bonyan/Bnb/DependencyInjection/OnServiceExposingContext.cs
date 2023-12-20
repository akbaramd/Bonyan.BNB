using Bonyan.Bnb.Statics;

namespace Bonyan.Bnb.DependencyInjection;

public class OnServiceExposingContext : IOnServiceExposingContext
{
    public Type ImplementationType { get; }

    public List<Type> ExposedTypes { get; }

    public OnServiceExposingContext(Type implementationType, List<Type> exposedTypes)
    {
        ImplementationType = BnbCheck.NotNull(implementationType, nameof(implementationType));
        ExposedTypes = BnbCheck.NotNull(exposedTypes, nameof(exposedTypes));
    }
}