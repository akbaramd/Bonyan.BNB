using Bonyan.Bnb.Statics;

namespace Bonyan.Bnb;

/// <summary>
/// This class can be used to provide an action when
/// Dispose method is called.
/// </summary>
public class BnbDisposeAction : IDisposable
{
    private readonly Action _action;

    /// <summary>
    /// Creates a new <see cref="BnbDisposeAction"/> object.
    /// </summary>
    /// <param name="action">Action to be executed when this object is disposed.</param>
    public BnbDisposeAction(Action action)
    {
        BnbCheck.NotNull(action, nameof(action));

        _action = action;
    }

    public void Dispose()
    {
        _action();
    }
}

/// <summary>
/// This class can be used to provide an action when
/// Dispose method is called.
/// <typeparam name="T">The type of the parameter of the action.</typeparam>
/// </summary>
public class BnbDisposeAction<T> : IDisposable
{
    private readonly Action<T> _action;

    private readonly T? _parameter;

    /// <summary>
    /// Creates a new <see cref="BnbDisposeAction"/> object.
    /// </summary>
    /// <param name="action">Action to be executed when this object is disposed.</param>
    /// <param name="parameter">The parameter of the action.</param>
    public BnbDisposeAction(Action<T> action, T parameter)
    {
        BnbCheck.NotNull(action, nameof(action));

        _action = action;
        _parameter = parameter;
    }

    public void Dispose()
    {
        if (_parameter != null)
        {
            _action(_parameter);
        }
    }
}
