﻿using System;
using Core.Domain.Customers;

namespace Core.Domain.Coupons
{
    public class CouponCustomer
    {
        public Customer Customer { get; private set; } = null!;
        public string CustomerId { get; private set; }


        public Coupon Coupon { get; private set; } = null!;
        public Guid CouponId { get; private set; }

        private CouponCustomer()
        {
        }
        
        public CouponCustomer(string customerId)
        {
            CustomerId = customerId;
        }
    }
}