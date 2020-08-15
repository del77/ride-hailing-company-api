using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Coupons
{
    public class Coupon : BaseEntity, IAggregateRoot
    {
        private Coupon()
        {
            CouponUsers = new List<CouponCustomer>();
        }

        public Coupon(string code, decimal discountPercent, int currentUsesCounter, int admissibleUses)
        {
            Code = code;
            SetDiscountPercent(discountPercent);
            SetAdmissibleUses(admissibleUses);
        }

        public string Code { get; }
        public decimal DiscountPercent { get; private set; }
        public int CurrentUsesCounter { get; private set; }
        public int AdmissibleUses { get; private set; }
        public ICollection<CouponCustomer> CouponUsers { get; }

        public void Use(string customerId)
        {
            CurrentUsesCounter += 1;
            CouponUsers.Add(new CouponCustomer(customerId));
        }

        public bool CanBeUsed(string customerId)
        {
            var canBeUsed = true;

            if (CurrentUsesCounter >= AdmissibleUses)
                canBeUsed = false;

            if (CouponUsers.Any(cu => cu.CustomerId == customerId))
                canBeUsed = false;

            return canBeUsed;
        }

        private void SetDiscountPercent(decimal discountPercent)
        {
            if (discountPercent <= 0 || discountPercent > 100)
                throw new Exception();

            DiscountPercent = discountPercent;
        }

        private void SetAdmissibleUses(int admissibleUses)
        {
            if (admissibleUses <= 0)
                throw new Exception();

            AdmissibleUses = admissibleUses;
        }
    }
}