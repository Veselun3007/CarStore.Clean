using CarStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Infrastructure.Context.Configurations
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(d => d.Id);
            builder.ToTable("dealers");

            builder.Property(d => d.Id).HasColumnName("dealer_id");
            builder.Property(d => d.Name).IsRequired().HasMaxLength(120).HasColumnName("name");
            builder.Property(d => d.ContactEmail).IsRequired().HasMaxLength(120).HasColumnName("contact_email");
        }
    }
}
