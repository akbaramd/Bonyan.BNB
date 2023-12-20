using Microsoft.Extensions.Logging;

namespace Bonyan.Bnb.Logging;

public interface IExceptionWithSelfLogging
{
    void Log(ILogger logger);
}
