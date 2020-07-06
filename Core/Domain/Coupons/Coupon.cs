using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Customers;

namespace Core.Domain.Coupons
{
    public class Coupon : BaseEntity, IAggregateRoot
    {
        public decimal DiscountPercent { get; private set; }
        public int CurrentUsesCounter { get; private set; }
        public int AdmissibleUses { get; private set; }
        public ICollection<CouponCustomer> CouponUsers { get; private set; }


        private Coupon()
        {
            CouponUsers = new List<CouponCustomer>();
        }
        
        public Coupon(decimal discountPercent, int currentUsesCounter, int admissibleUses)
        {
            SetDiscountPercent(discountPercent);
            SetAdmissibleUses(admissibleUses);
        }

        public void Use(Customer customer)
        {
            if(CurrentUsesCounter >= AdmissibleUses)
                throw new Exception();
            
            if(CouponUsers.Any(cu => cu.Customer == customer))
                throw new Exception("Coupon already used by this user.");

            CurrentUsesCounter += 1;
            CouponUsers.Add(new CouponCustomer(customer));
        }

        private void SetDiscountPercent(decimal discountPercent)
        {
            if(discountPercent <= 0 || discountPercent > 100)
                throw new Exception();

            DiscountPercent = discountPercent;
        }

        private void SetAdmissibleUses(int admissibleUses)
        {
            if(admissibleUses <= 0)
                throw new Exception();

            AdmissibleUses = admissibleUses;
        }
    }
}