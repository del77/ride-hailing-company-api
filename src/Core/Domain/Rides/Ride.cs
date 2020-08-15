using System;
using Core.Domain.Coupons;
using Core.Domain.Customers;
using Core.Domain.Drivers;
using Core.Exceptions;

namespace Core.Domain.Rides
{
    public class Ride : BaseEntity, IAggregateRoot
    {
        private Ride()
        {
        }

        public Ride(string customerId, string address, decimal originLatitude, decimal originLongitude)
        {
            CustomerId = customerId;
            Origin = new Node(address, originLatitude, originLongitude);
        }

        public string? DriverId { get; private set; }
        public Driver? Driver { get; private set; }

        public string CustomerId { get; }
        public Customer Customer { get; } = null!;

        public Node Origin { get; }
        public Node? Destination { get; private set; }

        public Money? Cost { get; private set; }

        public Guid? CouponId { get; private set; }
        public Coupon? Coupon { get; }

        public RideStatus Status { get; private set; }

        public byte[] Version { get; set; }

        public void AssignDriver(Driver driver)
        {
            if (!driver.IsAvailable)
                throw new DriverUnavailableException(driver.Id);

            if (Status != RideStatus.Requested)
                throw new InvalidRideStatusException(Status, Id);

            Driver = driver;
            Status = RideStatus.Accepted;
        }

        public void Cancel()
        {
            if (Status != RideStatus.Accepted)
                throw new Exception();

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
            var calculatedCost = new Money(pricePerKilometer.Currency, lengthInKilometers * pricePerKilometer.Value);

            Cost = calculatedCost;
            Status = RideStatus.Finished;
        }
    }
}