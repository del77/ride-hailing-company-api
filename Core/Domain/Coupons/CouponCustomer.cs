using System;
using Core.Domain.Customers;

namespace Core.Domain.Coupons
{
    public class CouponCustomer
    {
        public Customer Customer { get; private set; }
        public Guid CustomerId { get; private set; }
        
        
        public Coupon Coupon { get; private set; }
        public Guid CouponId { get; private set; }

        private CouponCustomer()
        {
        }
        
        public CouponCustomer(Customer customer)
        {
            Customer = customer;
        }
    }
}