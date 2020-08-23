using System;
using Core.Domain.Customers;
using Core.Exceptions;

namespace Core.Domain.Drivers
{
    public class Opinion : BaseEntity
    {
        private Opinion() { }
        
        public Opinion(int value, string description, string customerId)
        {
            if (value < 1 || value > 5)
                throw new InvalidOpinionValueException(value);

            Value = value;
            Description = description;
            CustomerId = customerId;
        }

        public string DriverId { get; } = null!;
        public string CustomerId { get; } = null!;
        public Customer Customer { get; } = null!;
        public int Value { get; }
        public string? Description { get; }
    }
}