using System;

namespace Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        public abstract string Code { get; }

        public DomainException(string message) : base(message)
        {
        }
    }
}