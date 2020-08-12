using Core.Domain.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(c => c.AdmissibleUses)
                .IsRequired();

            builder.Property(c => c.DiscountPercent)
                .IsRequired().HasColumnType(DatabaseTypes.Decimal);

            builder.Property(c => c.CurrentUsesCounter)
                .IsRequired();
        }
    }
}