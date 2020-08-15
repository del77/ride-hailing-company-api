namespace Core.Exceptions
{
    public class InvalidCouponCodeException : DomainException
    {
        public override string Code { get; } = "invalid_coupon_code";

        public InvalidCouponCodeException(string couponCode) : base($"Coupon code {couponCode} is invalid.")
        {
        }
    }
}