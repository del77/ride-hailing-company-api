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

            builder.OwnsOne(r => r.Origin);
            builder.OwnsOne(r => r.Destination);
            builder.OwnsOne(r => r.Cost);

            builder.HasOne(r => r.Coupon)
                .WithMany()
                .HasForeignKey(r => r.CouponId)
                .IsRequired(false);

            builder.Property(r => r.Status)
                .IsRequired();
        }
    }
}