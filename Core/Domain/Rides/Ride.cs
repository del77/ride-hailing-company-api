using System;
using System.Collections.Generic;
using Core.Domain.Coupons;
using Core.Domain.Customers;
using Core.Domain.Drivers;
using Core.Exceptions;

namespace Core.Domain.Rides
{
    public class Ride : BaseEntity, IAggregateRoot
    {
        public string? DriverId { get; private set; }
        public Driver? Driver { get; private set; } = null!;
        
        public string CustomerId { get; private set; }
        public Customer Customer { get; private set; } = null!;
        
        public Node Origin { get; private set; }
        public Node? Destination { get; private set; }

        public Money? Cost { get; private set; }
        
        public Guid? CouponId { get; private set; }
        public Coupon? Coupon { get; private set; }
        
        public RideStatus Status { get; private set; }
        
        private Ride() {}
        
        public Ride(string customerId, string address, decimal originLatitude, decimal origiLongitude, Coupon? coupon)
        {
            CustomerId = customerId;
            Origin = new Node(address, originLatitude, origiLongitude);
            
            if(coupon != null && !coupon.CanBeUsed(customerId))
                throw new Exception("Can't create ride with this coupon");
            
            Coupon = coupon;
        }
        
        public void AssignDriver(Driver driver)
        {
            if(!driver.IsAvailable)
                throw new DriverUnavailableException(driver.Id);

            if(Status != RideStatus.Requested)
                throw new InvalidRideStatusException(Status, Id);

            Driver = driver;
            Status = RideStatus.Accepted;
        }

        public void Cancel()
        {
            if(Status != RideStatus.Accepted)
                throw new Exception();

            Status = RideStatus.Canceled;
        }
        
        public void StartRide(string address, decimal destinationLatitude, decimal destinationLongitude)
        {
            if(Status != RideStatus.Accepted)
                throw new InvalidRideStatusException(Status, Id);

            Destination = new Node(address, destinationLatitude, destinationLongitude);
            Status = RideStatus.InProgress;
        }

        public void FinishRide(decimal lengthInKilometers, Money pricePerKilometer)
        {
            var calculatedCost = new Money(pricePerKilometer.Currency, lengthInKilometers * pricePerKilometer.Value);

            if (Coupon != null)
            {
                Coupon.Use(CustomerId);
                calculatedCost = calculatedCost.DecreaseByPercent(Coupon.DiscountPercent);
            }

            Cost = calculatedCost;
            Status = RideStatus.Finished;
        }
    }
}