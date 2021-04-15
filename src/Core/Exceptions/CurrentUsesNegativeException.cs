using System;

namespace Core.Exceptions
{
    public class CurrentUsesNegativeException : DomainException
    {
        public CurrentUsesNegativeException(Guid couponId) : base("") //todo: build exception message
        {
        }
    }
}