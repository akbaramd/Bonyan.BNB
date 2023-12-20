namespace Bonyan.Bnb.DependencyInjection;

public interface IObjectAccessor<out T>
{
    T? Value { get; }
}