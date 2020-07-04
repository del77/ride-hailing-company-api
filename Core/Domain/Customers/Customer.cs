using System;
using System.Collections.Generic;
using Core.Domain.Rides;

namespace Core.Domain.Customers
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public Guid IdentityId { get; private set; }
        public IEnumerable<Ride> Rides { get; private set; }
        

        private Customer()
        {
            Rides = new List<Ride>();
        }

        public Customer(Guid identityId)
        {
            if(identityId == Guid.Empty)
                throw new Exception();

            IdentityId = identityId;
        }
    }
}