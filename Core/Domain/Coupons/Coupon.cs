using System;

namespace Core.Domain.Coupons
{
    public class Coupon : BaseEntity, IAggregateRoot
    {
        public decimal DiscountPercent { get; private set; }
        public int CurrentUsesCounter { get; private set; }
        public int AdmissibleUses { get; private set; }

        public Coupon(decimal discountPercent, int currentUsesCounter, int admissibleUses)
        {
            SetDiscountPercent(discountPercent);
            SetAdmissibleUses(admissibleUses);
        }

        public void Use()
        {
            if(CurrentUsesCounter >= AdmissibleUses)
                throw new Exception();

            CurrentUsesCounter += 1;
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