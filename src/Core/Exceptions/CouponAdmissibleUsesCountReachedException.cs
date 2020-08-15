using System;

namespace Core.Exceptions
{
    public class CouponAdmissibleUsesCountReachedException : DomainException
    {
        public CouponAdmissibleUsesCountReachedException(Guid couponId, int admissibleUsesCount) : base(
            $"Coupon with id {couponId} uses quota ({admissibleUsesCount}) has been already reached.")
        {
        }
    }
}