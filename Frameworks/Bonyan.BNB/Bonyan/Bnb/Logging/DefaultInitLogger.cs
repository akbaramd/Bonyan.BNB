using Microsoft.Extensions.Logging;

namespace Bonyan.Bnb.Logging;

public class DefaultInitLogger<T> : IInitLogger<T>
{
    public List<BnbInitLogBnbry> Bnbries { get; }

    public DefaultInitLogger()
    {
        Bnbries = new List<BnbInitLogBnbry>();
    }

    public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        Bnbries.Add(new BnbInitLogBnbry
        {
            LogLevel = logLevel,
            EventId = eventId,
            State = state!,
            Exception = exception,
            Formatter = (s, e) => formatter((TState)s, e),
        });
    }

    public virtual bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None;
    }

    public virtual IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        return BnbNullDisposable.Instance;
    }
}
