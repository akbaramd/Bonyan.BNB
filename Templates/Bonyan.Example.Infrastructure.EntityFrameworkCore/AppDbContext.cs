using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.BNB.Identity.EntityFrameworkCore;
using Bonyan.Example.Domain.Aggregates.Products;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.Example.Infrastructure.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<AppDbContext>
{
    public DbSet<Product> Products { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}