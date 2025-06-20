using CarStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Infrastructure.Context.Configurations
{
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);
            builder.ToTable("sales");

            builder.Property(s => s.Id).HasColumnName("sale_id");
            builder.Property(s => s.SaleDate).IsRequired().HasColumnType("timestamp with time zone").HasColumnName("sale_date");
            builder.Property(s => s.FinalPrice).IsRequired().HasColumnType("numeric(18,2)").HasColumnName("final_price");
            builder.Property(s => s.UserId).HasColumnName("user_id").HasMaxLength(50);

            builder.HasOne(s => s.Car).WithMany().HasForeignKey(s => s.CarId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.User).WithMany(u => u.Sales).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
