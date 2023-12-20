namespace Bonyan.Bnb.DynamicProxy;

public abstract class BnbInterceptor : IBnbInterceptor
{
    public abstract Task InterceptAsync(IBnbMethodInvocation invocation);
}