using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.Domain.Roles;

namespace Bonyan.BNB.Identity.EntityFrameworkCore.Repositories;

public class IdentityRoleRepository<TDbContext>(TDbContext dbContext) : BnbEfRepository<TDbContext,IdentityRole,Guid>(dbContext), IIdentityRoleRepository where TDbContext : BnbDbContext<TDbContext>
{
    
}