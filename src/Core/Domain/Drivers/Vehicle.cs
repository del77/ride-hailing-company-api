using System.Collections.Generic;

namespace Core.Domain.Drivers
{
    public class Vehicle : ValueObject<Vehicle>
    {
        private Vehicle() { }
        
        public Vehicle(string registrationNumber, string brand, string model, int seats)
        {
            RegistrationNumber = registrationNumber;
            Brand = brand;
            Model = model;
            Seats = seats;
        }

        public string Brand { get; }
        public string Model { get; }
        public int Seats { get; }
        public string RegistrationNumber { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RegistrationNumber;
        }
    }
}