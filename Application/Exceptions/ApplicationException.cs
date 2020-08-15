using System;
using Shared;

namespace Application.Exceptions
{
    public abstract class ApplicationException : RideHailingException
    {
        public ApplicationException(string message) : base(message)
        {
        }

        public ApplicationException(string message, Exception e) : base(message, e)
        {
        }
    }
}