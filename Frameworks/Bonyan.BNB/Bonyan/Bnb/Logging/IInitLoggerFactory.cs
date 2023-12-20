namespace Bonyan.Bnb.Logging;

public interface IInitLoggerFactory
{
    IInitLogger<T> Create<T>();
}
