using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.Domain.Roles;
using Bonyan.BNB.Identity.Domain.Users;
using Bonyan.BNB.Identity.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.BNB.Identity.EntityFrameworkCore;

public class IdentityDbContext<TDbContext> : BnbDbContext<TDbContext> where TDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<TDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<Role>(new RoleConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}