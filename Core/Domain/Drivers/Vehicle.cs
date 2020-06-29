using System;

namespace Core.Domain.Drivers
{
    public class Vehicle : BaseEntity
    {
        public Guid DriverId { get; private set; }
        
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Seats { get; private set; }

        public Vehicle(Guid driverId, string brand, string model, int seats)
        {
            DriverId = driverId;
            Brand = brand;
            Model = model;
            Seats = seats;
        }
    }
}