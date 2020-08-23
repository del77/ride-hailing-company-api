using System.Collections.Generic;

namespace Core.Domain.Rides
{
    public class Node : ValueObject<Node>
    {
        private Node() { }
        
        public Node(string address, decimal latitude, decimal longitude)
        {
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Address { get; }
        public decimal Latitude { get; }
        public decimal Longitude { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}