namespace Bonyan.Bnb.ExceptionHandling;

public interface IExceptionSubscriber
{
    Task HandleAsync( ExceptionNotificationContext context);
}
