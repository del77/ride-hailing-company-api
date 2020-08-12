using Core.Domain.Rides;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration
{
    public class RideConfiguration : IEntityTypeConfiguration<Ride>
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
            builder.HasOne(r => r.Driver)
                .WithMany(d => d.Rides)
                .HasForeignKey(r => r.DriverId);

            builder.HasOne(r => r.Customer)
                .WithMany(c => c.Rides)
                .HasForeignKey(r => r.CustomerId);

            builder.OwnsOne(r => r.Origin, node =>
            {
                node.Property(o => o.Latitude).HasColumnType(DatabaseTypes.Decimal);
                node.Property(p => p.Longitude).HasColumnType(DatabaseTypes.Decimal);
            });
            
            builder.OwnsOne(r => r.Destination, node =>
            {
                node.Property(d => d.Latitude).HasColumnType(DatabaseTypes.Decimal);
                node.Property(d => d.Longitude).HasColumnType(DatabaseTypes.Decimal);
            });
            
            builder.OwnsOne(r => r.Cost, money =>
            {
                money.Property(m => m.Value).HasColumnType(DatabaseTypes.Decimal);
            });

            builder.HasOne(r => r.Coupon)
                .WithMany()
                .HasForeignKey(r => r.CouponId)
                .IsRequired(false);

            builder.Property(r => r.Status)
                .IsRequired();

            builder.Property(r => r.Version)
                .IsRowVersion();
        }
    }
}