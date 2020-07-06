using Core.Domain.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration
{
    public class CouponCustomerConfiguration : IEntityTypeConfiguration<CouponCustomer>
    {
        public void Configure(EntityTypeBuilder<CouponCustomer> builder)
        {
            builder.HasKey(cc => new {cc.CouponId, cc.CustomerId});

            builder.HasOne(cc => cc.Customer)
                .WithMany()
                .HasForeignKey(cc => cc.CustomerId)
                .IsRequired();

            builder.HasOne(cc => cc.Coupon)
                .WithMany(c => c.CouponUsers)
                .HasForeignKey(cc => cc.CouponId)
                .IsRequired();
        }
    }
}