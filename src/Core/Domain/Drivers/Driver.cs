using System.Collections.Generic;
using System.Linq;
using Core.Domain.Rides;
using Core.Exceptions;

namespace Core.Domain.Drivers
{
    public class Driver : IAggregateRoot
    {
        private Driver()
        {
            Opinions = new List<Opinion>();
            Rides = new List<Ride>();
        }

        public Driver(string id) : this()
        {
            Id = id;
            Vehicle = new Vehicle("123", "ford", "mustang", 4);
        }

        public string Id { get; } = null!;
        public IEnumerable<Opinion> Opinions { get; } = null!;
        public IEnumerable<Ride> Rides { get; } = null!;
        public Vehicle Vehicle { get; } = null!;
        public bool IsAvailable => Rides.All(r => r.Status != RideStatus.Accepted && r.Status != RideStatus.InProgress);

        public void AddOpinion(in int value, string description, string customerId)
        {
            var isAlreadyRatedByUser = Opinions.Any(o => o.CustomerId == customerId);
            if (isAlreadyRatedByUser)
                throw new AlreadyRatedException(Id, customerId);
            
            var opinion = new Opinion(value, description, customerId);
        }
    }
}