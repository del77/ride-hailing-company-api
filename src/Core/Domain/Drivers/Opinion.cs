using System;
using Core.Domain.Customers;
using Core.Exceptions;

namespace Core.Domain.Drivers
{
    public class Opinion : Entity
    {
        public string DriverId { get; private set; }
        public string CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public int Value { get; private set; }
        public string Description { get; private set; }
        private Opinion() { }
        
        public Opinion(int value, string description, string customerId)
        {
            SetValue(value);
            Description = description;
            CustomerId = customerId;
        }

        private void SetValue(int value)
        {
            if (value < 1 || value > 5)
                throw new InvalidOpinionValueException(value);

            Value = value; 
        }
    }
}