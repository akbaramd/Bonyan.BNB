using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.DDD.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Bonyan.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionRepositoryExtensions
{
    public static IServiceCollection AddDefaultRepository(
        this IServiceCollection services,
        Type entityType,
        Type repositoryImplementationType,
        bool replaceExisting = false)
    {
        var primaryKeyType = EntityHelper.FindPrimaryKeyType(entityType);
        if (primaryKeyType != null)
        {
            //IReadOnlyRepository<TEntity, TKey>
            var readOnlyRepositoryInterfaceWithPk = typeof(IReadOnlyRepository<,>).MakeGenericType(entityType, primaryKeyType);
            if (readOnlyRepositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
            {
                RegisterService(services, readOnlyRepositoryInterfaceWithPk, repositoryImplementationType, replaceExisting, true);
            }
        
            //IRepository<TEntity, TKey>
            var repositoryInterfaceWithPk = typeof(IRepository<,>).MakeGenericType(entityType, primaryKeyType);
            if (repositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
            {
                RegisterService(services, repositoryInterfaceWithPk, repositoryImplementationType, replaceExisting);
            }
        }

        return services;
    }

    private static void RegisterService(
        IServiceCollection services,
        Type serviceType,
        Type implementationType,
        bool replaceExisting,
        bool isReadOnlyRepository = false)
    {
        ServiceDescriptor descriptor;

        if (isReadOnlyRepository)
        {
            services.TryAddTransient(implementationType);
            descriptor = ServiceDescriptor.Transient(serviceType, provider =>
            {
                var repository = provider.GetRequiredService(implementationType);
                // ObjectHelper.TrySetProperty(repository.As<IRepository>(), x => x.IsChangeTrackingEnabled, _ => false);
                return repository;
            });
        }
        else
        {
            descriptor = ServiceDescriptor.Transient(serviceType, implementationType);
        }

        if (replaceExisting)
        {
            services.Replace(descriptor);
        }
        else
        {
            services.TryAdd(descriptor);
        }
    }
}