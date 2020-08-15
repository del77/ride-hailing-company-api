using System;

namespace Shared
{
    public abstract class RideHailingException : Exception
    {
        protected RideHailingException(string message) : base(message)
        {
        }

        protected RideHailingException(string message, Exception e) : base(message, e)
        {
        }

        public virtual string Code { get; } = "error";
    }
}