namespace Bonyan.Bnb.DynamicProxy;

public interface IBnbInterceptor
{
    Task InterceptAsync(IBnbMethodInvocation invocation);
}