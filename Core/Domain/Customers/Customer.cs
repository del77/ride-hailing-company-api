using System;
using System.Collections.Generic;
using Core.Domain.Rides;

namespace Core.Domain.Customers
{
    public class Customer : IAggregateRoot
    {
        public string Id { get; private set; }
        public IEnumerable<Ride> Rides { get; private set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; private set; }

        private Customer()
        {
            Rides = new List<Ride>();
            PaymentMethods = new List<PaymentMethod>();
        }

        public Customer(string id)
        {
            if(id is null)
                throw new Exception();

            Id = id;
        }
    }
}