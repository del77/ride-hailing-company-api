using System;
using System.Collections.Generic;
using System.Linq;
using Core.Exceptions;

namespace Core.Domain.Coupons
{
    public class Coupon : Entity, IAggregateRoot
    {
        private readonly HashSet<CouponCustomer> _couponUsers;

        private Coupon()
        {
            _couponUsers = new HashSet<CouponCustomer>();
        }

        public Coupon(string code, decimal discountPercent, int currentUsesCounter, int admissibleUses) : this()
        {
            Code = code;
            SetCurrentUsesCounter(currentUsesCounter);
            SetDiscountPercent(discountPercent);
            SetAdmissibleUses(admissibleUses);
        }

        public string Code { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public int CurrentUsesCounter { get; private set; }
        public int AdmissibleUses { get; private set; }

        public IReadOnlyCollection<CouponCustomer> CouponUsers => _couponUsers;

        public void Use(string customerId)
        {
            if (IsUsesQuotaReached)
            {
                throw new CouponAdmissibleUsesCountReachedException(Id, AdmissibleUses);
            }
            
            if(IsCouponAlreadyUsedByCustomer(customerId))
            {
                throw new CouponAlreadyUsedByCustomerException(customerId, Id);
            }

            CurrentUsesCounter += 1;
            _couponUsers.Add(new CouponCustomer(customerId));
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

        private bool IsUsesQuotaReached => CurrentUsesCounter >= AdmissibleUses;
        private bool IsCouponAlreadyUsedByCustomer(string customerId) => CouponUsers.Any(cu => cu.CustomerId == customerId);

        private void SetCurrentUsesCounter(int currentUsesCounter)
        {
            if (currentUsesCounter < 0)
            {
                throw new CurrentUsesNegativeException(Id);
            }

            CurrentUsesCounter = currentUsesCounter;
        }
        
        private void SetDiscountPercent(decimal discountPercent)
        {
            if (discountPercent <= 0 || discountPercent > 100)
                throw new ProvidedDiscountIsNegativeException(Id);

            DiscountPercent = discountPercent;
        }

        private void SetAdmissibleUses(int admissibleUses)
        {
            if (admissibleUses <= 0)
                throw new CouponAdmissibleUsesCountReachedException(Id, admissibleUses);

            AdmissibleUses = admissibleUses;
        }
    }
}