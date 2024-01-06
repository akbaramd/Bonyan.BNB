using Microsoft.EntityFrameworkCore;

namespace Bonyan.BNB.EntityFrameworkCore;

public class BnbDbContext<TDbContext> : DbContext where TDbContext : DbContext
{
    public BnbDbContext(DbContextOptions<TDbContext> options):base(options)
    {
        
    }
}