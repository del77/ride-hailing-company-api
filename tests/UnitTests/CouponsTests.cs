using System.Diagnostics.Contracts;
using Core.Domain.Coupons;
using Core.Exceptions;
using Xunit;

namespace UnitTests
{
    public class CouponsTests
    {
        [Fact]
        public void Should_IncrementCurrentUsesCounter_When_CouponIsUsed()
        {
            const int initialUsesCount = 0;
            var coupon = new Coupon("code", 10, initialUsesCount, 10);
            
            coupon.Use("customerId");
            
            Assert.Equal(coupon.CurrentUsesCounter, initialUsesCount + 1);
        }
        
        [Fact]
        public void Should_Throw_When_CouponWasAlreadyUsedByThisUser()
        {
            const string customerId = "customerId";
            var coupon = new Coupon("code", 10, 0, 10);
            coupon.Use(customerId);

            Assert.Throws<CouponAlreadyUsedByCustomerException>(() => coupon.Use(customerId));
        }
        
        [Fact]
        public void Should_Throw_When_CouponAdmissibleHasBeenReached()
        {
            const int initialUsesCount = 10;
            var coupon = new Coupon("code", 10, initialUsesCount, initialUsesCount);
            
            Assert.Throws<CouponAdmissibleUsesCountReachedException>(() => coupon.Use("customerId"));
        }
    }
}