using CarStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Infrastructure.Context.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable("users");

            builder.Property(u => u.Id).HasColumnName("user_id").HasMaxLength(40);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(200).HasColumnName("user_name");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(120).HasColumnName("email");
        }
    }
}
