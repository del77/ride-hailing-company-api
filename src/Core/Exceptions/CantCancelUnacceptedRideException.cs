using System;

namespace Core.Exceptions
{
    public class CantCancelUnacceptedRideException : DomainException
    {
        public CantCancelUnacceptedRideException(Guid rideId) : base("") //todo: exception message
        {
        }
    }
}