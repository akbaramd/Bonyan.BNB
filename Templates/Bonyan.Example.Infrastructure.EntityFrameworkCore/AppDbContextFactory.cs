using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bonyan.Example.Infrastructure.EntityFrameworkCore
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=.;initial catalog=BonyanExample;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True;";
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connectionString);
            var options = builder.Options;

            return new AppDbContext(options);
        }
    }
}