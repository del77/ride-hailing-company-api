using System.Collections.Generic;
using Core.Domain.Rides;

namespace Core.Domain.Customers
{
    public class Customer : IAggregateRoot
    {
        private Customer()
        {
            Rides = new List<Ride>();
            PaymentMethods = new List<PaymentMethod>();
        }

        public Customer(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public IEnumerable<Ride> Rides { get; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; }
    }
}