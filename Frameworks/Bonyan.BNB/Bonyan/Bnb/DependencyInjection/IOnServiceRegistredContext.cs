using Bonyan.Bnb.Collections;
using Bonyan.Bnb.DynamicProxy;

namespace Bonyan.Bnb.DependencyInjection;

public interface IOnServiceRegistredContext
{
    ITypeList<IBnbInterceptor> Interceptors { get; }

    Type ImplementationType { get; }
}