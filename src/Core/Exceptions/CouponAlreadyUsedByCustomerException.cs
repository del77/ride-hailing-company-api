using System;

namespace Core.Exceptions
{
    public class CouponAlreadyUsedByCustomerException : DomainException
    {
        public override string Code { get; } = "coupon_already_used";

        public CouponAlreadyUsedByCustomerException(string userId, Guid couponId) : base(
            $"User with id {userId} cannot use coupon with id {couponId} more than once.")
        {
        }
    }
}