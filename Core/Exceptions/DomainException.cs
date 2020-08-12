using System;
using Shared;

namespace Core.Exceptions
{
    public abstract class DomainException : RideHailingException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}