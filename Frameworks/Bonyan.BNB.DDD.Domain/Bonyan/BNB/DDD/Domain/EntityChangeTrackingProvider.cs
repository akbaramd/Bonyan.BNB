using Bonyan.Bnb;
using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.BNB.Domain.Repository;

public class EntityChangeTrackingProvider : IEntityChangeTrackingProvider, ISingletonDependency
{
    public bool? Enabled => _current.Value;

    private readonly AsyncLocal<bool?> _current = new AsyncLocal<bool?>();

    public IDisposable Change(bool? enabled)
    {
        var previousValue = Enabled;
        _current.Value = enabled;
        return new BnbDisposeAction(() => _current.Value = previousValue);
    }
}
