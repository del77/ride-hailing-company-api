using System;

namespace Core.Exceptions
{
    public class ProvidedDiscountIsNegativeException : DomainException
    {
        public ProvidedDiscountIsNegativeException(Guid couponId) : base("") // todo: build message
        {
        }
    }
}