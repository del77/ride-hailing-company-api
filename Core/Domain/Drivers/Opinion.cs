using System;

namespace Core.Domain.Drivers
{
    public class Opinion : BaseEntity
    {
        public Opinion(int value, string description)
        {
            if (value < 1 || value > 5)
                throw new Exception("Wrong value");

            Value = value;
            Description = description;
        }

        public string DriverId { get; private set; }
        public int Value { get; }
        public string Description { get; set; }
    }
}