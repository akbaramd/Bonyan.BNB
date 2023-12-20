using System.Runtime.Serialization;

namespace Bonyan.Bnb.Exceptions;

public class BnbException : Exception
{
    public BnbException()
    {
    }

    public BnbException(string? message)
        : base(message)
    {
    }

    public BnbException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public BnbException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
    {
    }
}