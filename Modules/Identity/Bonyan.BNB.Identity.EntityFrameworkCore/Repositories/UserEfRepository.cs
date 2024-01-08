using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.EntityFrameworkCore.Repositories;

public class IdentityUserRepository<TDbContext>(TDbContext dbContext) : BnbEfRepository<TDbContext,IdentityUser,Guid>(dbContext), IIdentityUserRepository where TDbContext : BnbDbContext<TDbContext>
{
    
}