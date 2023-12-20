using Microsoft.Extensions.Logging;

namespace Bonyan.Bnb.Logging;

/// <summary>
/// Interface to define a <see cref="LogLevel"/> property (see <see cref="LogLevel"/>).
/// </summary>
public interface IHasLogLevel
{
    /// <summary>
    /// Log severity.
    /// </summary>
    LogLevel LogLevel { get; set; }
}