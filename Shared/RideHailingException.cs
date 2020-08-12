using System;

namespace Shared
{
    public abstract class RideHailingException : Exception
    {
        public abstract string Code { get; }

        protected RideHailingException(string message) : base(message)
        {
        }

        protected RideHailingException(string message, Exception e) : base(message, e)
        {
        }
    }
}