using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.Domain.Roles;
using Bonyan.BNB.Identity.Domain.Users;
using Bonyan.BNB.Identity.EntityFrameworkCore.Repositories;
using Bonyan.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.Identity.EntityFrameworkCore;

public static class Extensions
{
    public static IServiceCollection AddBnbIdentityDbContext<TDbContext>(
        this IServiceCollection services,
        Action<BnbDbContextOptions> optionsBuilder) where TDbContext : BnbDbContext<TDbContext>

    {
        services.AddBnbDbContext<TDbContext>(optionsBuilder);
        services.AddDefaultRepository(typeof(User),typeof(UserRepository<TDbContext>));
        services.AddDefaultRepository(typeof(Role),typeof(RoleRepository<TDbContext>));

        services.AddScoped<IUserRepository, UserRepository<TDbContext>>();
        services.AddScoped<IRoleRepository, RoleRepository<TDbContext>>();
        
        return services;
    }
}