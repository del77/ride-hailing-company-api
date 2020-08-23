using System;
using Core.Domain.Customers;

namespace Core.Domain.Coupons
{
    public class CouponCustomer
    {
        private CouponCustomer()
        {
        }

        public CouponCustomer(string customerId)
        {
            CustomerId = customerId;
        }

        public Customer Customer { get; } = null!;
        public string CustomerId { get; } = null!;


        public Coupon Coupon { get; } = null!;
        public Guid CouponId { get; private set; }
    }
}