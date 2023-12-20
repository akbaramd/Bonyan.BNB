using Microsoft.Extensions.Logging;

namespace Bonyan.Bnb.Logging;

public interface IInitLogger<out T> : ILogger<T>
{
    public List<BnbInitLogBnbry> Bnbries { get; }
}
