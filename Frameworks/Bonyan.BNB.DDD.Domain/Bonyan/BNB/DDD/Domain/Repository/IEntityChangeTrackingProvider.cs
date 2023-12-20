namespace Bonyan.BNB.Domain.Repository;

public interface IEntityChangeTrackingProvider
{
    bool? Enabled { get; }

    IDisposable Change(bool? enabled);
}
