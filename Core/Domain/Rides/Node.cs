using System.Collections.Generic;

namespace Core.Domain.Rides
{
    public class Node : ValueObject<Node>
    {
        public string Address { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        public Node(string address, decimal latitude, decimal longitude)
        {
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}