using CarStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Infrastructure.Context.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("cars");

            builder.Property(c => c.Id).HasColumnName("car_id");
            builder.Property(c => c.Maker).IsRequired().HasMaxLength(120).HasColumnName("maker");
            builder.Property(c => c.Model).IsRequired().HasMaxLength(120).HasColumnName("model");
            builder.Property(c => c.Year).IsRequired().HasColumnName("year");
            builder.Property(c => c.Price).IsRequired().HasColumnType("numeric(18, 2)").HasColumnName("price");
            builder.Property(c => c.DealerId).HasColumnName("dealer_id");

            builder.HasOne(c => c.Dealer).WithMany(d => d.Cars).HasForeignKey(c => c.DealerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
