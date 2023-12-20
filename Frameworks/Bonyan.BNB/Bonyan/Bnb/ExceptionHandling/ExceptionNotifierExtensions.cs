using Bonyan.Bnb.Statics;
using Microsoft.Extensions.Logging;

namespace Bonyan.Bnb.ExceptionHandling;

public static class ExceptionNotifierExtensions
{
    public static Task NotifyAsync(
        this IExceptionNotifier exceptionNotifier,
        Exception exception,
        LogLevel? logLevel = null,
        bool handled = true)
    {
        BnbCheck.NotNull(exceptionNotifier, nameof(exceptionNotifier));

        return exceptionNotifier.NotifyAsync(
            new ExceptionNotificationContext(
                exception,
                logLevel,
                handled
            )
        );
    }
}
