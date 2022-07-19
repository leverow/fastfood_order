using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fastfood_order.Entity;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.UserId);
        builder.HasIndex(b => b.ChatId).IsUnique(false);
        builder.Property(b => b.FirstName).HasMaxLength(255);
        builder.Property(b => b.LastName).HasMaxLength(255);
        builder.Property(b => b.LanguageCode).HasMaxLength(3).IsRequired();
    }
}