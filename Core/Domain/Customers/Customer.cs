using System;
using System.Collections.Generic;
using Core.Domain.Rides;
using Core.Exceptions;

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
            Id = id;
        }
    }
}