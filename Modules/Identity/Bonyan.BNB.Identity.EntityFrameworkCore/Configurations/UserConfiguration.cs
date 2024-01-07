using Bonyan.BNB.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bonyan.BNB.Identity.EntityFrameworkCore.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
 
        builder.ToTable("Users");
        
        builder.Property(x => x.MobileNumber).IsRequired(false);
        builder.Property(x => x.Email).IsRequired(false);
        
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.MobileNumber).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
        
        builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity(
                "UserRoles");

    }
}