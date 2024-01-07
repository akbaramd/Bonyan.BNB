using Bonyan.BNB.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.Example.Infrastructure.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<AppDbContext>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}