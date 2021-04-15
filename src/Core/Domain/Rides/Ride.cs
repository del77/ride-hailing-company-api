using System;
using Core.Domain.Coupons;
using Core.Domain.Customers;
using Core.Domain.Drivers;
using Core.Exceptions;

namespace Core.Domain.Rides
{
    public class Ride : Entity, IAggregateRoot
    {
        private Ride()
        {
        }

        public Ride(string customerId, string address, decimal originLatitude, decimal originLongitude, Coupon coupon)
        {
            CustomerId = customerId;
            Origin = new Node(address, originLatitude, originLongitude);

            coupon?.Use(customerId);
        }

        public string DriverId { get; private set; }
        public Driver Driver { get; private set; }

        public string CustomerId { get; } = null!;
        public Customer Customer { get; } = null!;

        public Node Origin { get; } = null!;
        public Node Destination { get; private set; }

        public Money Cost { get; private set; }

        public Guid? CouponId { get; private set; }
        public Coupon Coupon { get; private set; }

        public RideStatus Status { get; private set; }
        public bool IsPaid { get; private set; }

        public byte[] Version { get; set; } = null!;

        public void AssignDriver(Driver driver)
        {
            if (!driver.IsAvailable)
            {
                throw new DriverUnavailableException(driver.Id);
            }

            if (Status != RideStatus.Requested)
            {
                throw new InvalidRideStatusException(Status, Id);
            }

            Driver = driver;
            Status = RideStatus.Accepted;
        }

        public void Cancel()
        {
            if (Status != RideStatus.Accepted)
            {
                throw new CantCancelUnacceptedRideException(Id);
            }

            Status = RideStatus.Canceled;
        }

        public void StartRide(string address, decimal destinationLatitude, decimal destinationLongitude)
        {
            if (Status != RideStatus.Accepted)
                throw new InvalidRideStatusException(Status, Id);

            Destination = new Node(address, destinationLatitude, destinationLongitude);
            Status = RideStatus.InProgress;
        }

        public void FinishRide(decimal lengthInKilometers, Money pricePerKilometer)
        {
            if(Status != RideStatus.InProgress)
            {
                throw new InvalidRideStatusException(Status, Id);
            }
            
            Status = RideStatus.Finished;
            Cost = CalculateCost(lengthInKilometers, pricePerKilometer);
        }

        public void MarkAsPaid()
        {
            if (Status != RideStatus.Finished)
            {
                throw new InvalidRideStatusException(Status, Id);
            }

            IsPaid = true;
        }
        
        private Money CalculateCost(decimal lengthInKilometers, Money pricePerKilometer)
        {
            var calculatedCost = new Money(pricePerKilometer.Currency, lengthInKilometers * pricePerKilometer.Value);

            if (Coupon != null)
            {
                calculatedCost.DecreaseByPercent(Coupon.DiscountPercent);
            }

            return calculatedCost;
        }
    }
}