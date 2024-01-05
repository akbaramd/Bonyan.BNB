namespace Bonyan.BNB.DDD.Domain;

public interface IEntityChangeTrackingProvider
{
    bool? Enabled { get; }

    IDisposable Change(bool? enabled);
}
