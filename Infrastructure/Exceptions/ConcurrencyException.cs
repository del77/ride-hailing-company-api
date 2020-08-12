using System;

namespace Infrastructure.Exceptions
{
    public class ConcurrencyException : InfrastructureException
    {
        public ConcurrencyException(Exception e) : base("Concurrency exception occured when trying to save.", e)
        {
        }

        public override string Code => "concurrency_error";
    }
}