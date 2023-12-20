namespace Bonyan.Bnb;

public interface IBnbApplicationInfoAccessor
{
    string? ApplicationName { get; }
    string InstanceId { get; }
}