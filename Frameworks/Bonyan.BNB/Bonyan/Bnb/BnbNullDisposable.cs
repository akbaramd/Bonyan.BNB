namespace Bonyan.Bnb;

public sealed class BnbNullDisposable : IDisposable
{
    public static BnbNullDisposable Instance { get; } = new BnbNullDisposable();

    private BnbNullDisposable()
    {

    }

    public void Dispose()
    {

    }
}
