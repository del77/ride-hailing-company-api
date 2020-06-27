using System;
using Core.Domain.Customers;
using Core.Domain.Drivers;

namespace Core.Domain.Rides
{
    public class Ride : BaseEntity
    {
        public Guid DriverId { get; private set; }
        public Driver Driver { get; private set; }
        
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        
        public Node Origin { get; private set; }
        public Node Destination { get; private set; }
        
        public Money Cost { get; private set; }
        
        public RideStatus Status { get; private set; }

        public void AssignDriver(Guid driverId)
        {
            if(Status != RideStatus.Requested)
                throw new Exception();
            
            DriverId = driverId;
            Status = RideStatus.Accepted;
        }

        public void Cancel()
        {
            if(Status != RideStatus.Accepted)
                throw new Exception();

            Status = RideStatus.Canceled;
        }
        
        public void StartRide()
        {
            if(Status != RideStatus.Accepted)
                throw new Exception();

            Status = RideStatus.InProgress;
        }
    }
}