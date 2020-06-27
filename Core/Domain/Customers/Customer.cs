using System;
using System.Collections.Generic;
using Core.Domain.Rides;

namespace Core.Domain.Customers
{
    public class Customer
    {
        public Guid UserId { get; private set; }
        public IEnumerable<Ride> Rides { get; private set; }
        

        public Customer()
        {
            Rides = new List<Ride>();
        }
    }
}