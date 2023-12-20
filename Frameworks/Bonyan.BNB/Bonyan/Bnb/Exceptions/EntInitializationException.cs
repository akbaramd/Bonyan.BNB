namespace Bonyan.Bnb.Exceptions;

public class BnbInitializationException : BnbException
{
    public BnbInitializationException(string? message) : base(message)
    {
    }

    public BnbInitializationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}