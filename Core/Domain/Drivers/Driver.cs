using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Rides;
using Core.Exceptions;

namespace Core.Domain.Drivers
{
    public class Driver : IAggregateRoot
    {
        public string Id { get; private set; }
        public IEnumerable<Opinion> Opinions { get; private set; }
        public IEnumerable<Ride> Rides { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public bool IsAvailable => Rides.All(r => r.Status != RideStatus.Accepted && r.Status != RideStatus.InProgress);
        
        private Driver()
        {
            Opinions = new List<Opinion>();
            Rides = new List<Ride>();
        }

        public Driver(string id)
        {
            Id = id;
            Vehicle = new Vehicle("123", "ford", "mustang", 4);
        }
    }
}