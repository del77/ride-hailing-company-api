using System.Collections.Generic;
using System.Linq;
using Core.Domain.Rides;
using Core.Exceptions;

namespace Core.Domain.Drivers
{
    public class Driver : IAggregateRoot
    {
        private readonly HashSet<Opinion> _opinions;

        private Driver()
        {
            _opinions = new HashSet<Opinion>();
            Rides = new List<Ride>();
        }

        public Driver(string id) : this()
        {
            Id = id;
        }

        public string Id { get; }

        public IEnumerable<Opinion> Opinions => _opinions;

        public IEnumerable<Ride> Rides { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public bool IsAvailable => Rides.All(r => r.Status != RideStatus.Accepted && r.Status != RideStatus.InProgress);

        public void AddOpinion(in int value, string description, string customerId)
        {
            var isAlreadyRatedByUser = Opinions.Any(o => o.CustomerId == customerId);
            if (isAlreadyRatedByUser)
                throw new AlreadyRatedException(Id, customerId);
            
            var opinion = new Opinion(value, description, customerId);
            _opinions.Add(opinion);
        }
    }
}