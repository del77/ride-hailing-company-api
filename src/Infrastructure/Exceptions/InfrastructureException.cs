using System;
using Shared;

namespace Infrastructure.Exceptions
{
    public abstract class InfrastructureException : RideHailingException
    {
        public InfrastructureException(string message) : base(message)
        {
        }

        public InfrastructureException(string message, Exception e) : base(message, e)
        {
        }
    }
}