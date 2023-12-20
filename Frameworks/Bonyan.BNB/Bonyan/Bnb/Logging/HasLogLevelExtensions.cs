using Bonyan.Bnb.Statics;
using Microsoft.Extensions.Logging;

namespace Bonyan.Bnb.Logging;

public static class HasLogLevelExtensions
{
    public static TException WithLogLevel<TException>(this TException exception, LogLevel logLevel)
        where TException : IHasLogLevel
    {
        BnbCheck.NotNull(exception, nameof(exception));

        exception.LogLevel = logLevel;

        return exception;
    }
}
