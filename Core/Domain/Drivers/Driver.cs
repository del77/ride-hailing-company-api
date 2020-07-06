using System;
using System.Collections.Generic;
using Core.Domain.Rides;

namespace Core.Domain.Drivers
{
    public class Driver : BaseEntity, IAggregateRoot
    {
        public Guid IdentityId { get; private set; }
        public IEnumerable<Opinion> Opinions { get; private set; }
        public IEnumerable<Ride> Rides { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public Driver()
        {
            Opinions = new List<Opinion>();
            Rides = new List<Ride>();
        }
        
        public Driver(Guid identityId)
        {
            IdentityId = identityId;
            Vehicle = new Vehicle("123", "ford", "mustang", 4);
        }
    }
}