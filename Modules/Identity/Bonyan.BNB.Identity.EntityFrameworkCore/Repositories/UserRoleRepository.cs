using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.Domain.Roles;

namespace Bonyan.BNB.Identity.EntityFrameworkCore.Repositories;

public class RoleRepository<TDbContext>(TDbContext dbContext) : BnbEfRepository<TDbContext,Role,Guid>(dbContext), IRoleRepository where TDbContext : BnbDbContext<TDbContext>
{
    
}