using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorAuthAPI.Core.Data.EntityConfig;

public class UserEntityConfig : IEntityTypeConfiguration<User.Entities.User>
{
    public void Configure(EntityTypeBuilder<User.Entities.User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
        builder.Property(x => x.Role).HasMaxLength(10);
    }
}

