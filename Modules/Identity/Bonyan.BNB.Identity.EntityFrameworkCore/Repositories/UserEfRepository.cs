using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.BNB.Identity.EntityFrameworkCore.Repositories;

public class UserRepository<TDbContext>(TDbContext dbContext) : BnbEfRepository<TDbContext,User,Guid>(dbContext), IUserRepository where TDbContext : BnbDbContext<TDbContext>
{
    
}