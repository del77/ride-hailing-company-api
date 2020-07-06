using System;
using System.Collections.Generic;
using Core.Domain.Coupons;
using Core.Domain.Customers;
using Core.Domain.Drivers;

namespace Core.Domain.Rides
{
    public class Ride : BaseEntity, IAggregateRoot
    {
        public Guid DriverId { get; private set; }
        public Driver Driver { get; private set; } = null!;
        
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; } = null!;
        
        public Node Origin { get; private set; }
        public Node Destination { get; private set; }

        public Money? Cost { get; private set; }
        
        public Guid? CouponId { get; private set; }
        public Coupon? Coupon { get; private set; }
        
        public RideStatus Status { get; private set; }
        
        private Ride() {}
        
        public Ride(Guid driverId, Guid customerId, Node origin, Node destination, Coupon coupon)
        {
            DriverId = driverId;
            CustomerId = customerId;
            Origin = origin;
            Destination = destination;
        }

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

        public void FinishRide(decimal lengthInKilometers, Money pricePerKilometer)
        {
            var calculatedCost = new Money(pricePerKilometer.Currency, lengthInKilometers * pricePerKilometer.Value);

            if (Coupon != null)
            {
                Coupon.Use(Customer);
                calculatedCost = calculatedCost.DecreaseByPercent(Coupon.DiscountPercent);
            }

            Cost = calculatedCost;
            Status = RideStatus.Finished;
        }
    }
}