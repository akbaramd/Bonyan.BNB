using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.Domain.Roles;
using Bonyan.BNB.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.BNB.Identity.EntityFrameworkCore.Repositories;

public class RoleRepository<TDbContext>(TDbContext dbContext) : BnbEfRepository<TDbContext,Role,Guid>(dbContext), IRoleRepository where TDbContext : BnbDbContext<TDbContext>
{
    
}