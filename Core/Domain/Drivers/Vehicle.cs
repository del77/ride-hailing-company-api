using System;
using System.Collections.Generic;

namespace Core.Domain.Drivers
{
    public class Vehicle : ValueObject<Vehicle>
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Seats { get; private set; }
        public string RegistrationNumber { get; private set; }

        public Vehicle(string registrationNumber, string brand, string model, int seats)
        {
            RegistrationNumber = registrationNumber;
            Brand = brand;
            Model = model;
            Seats = seats;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RegistrationNumber;
        }
    }
}