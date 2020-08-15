using System;

namespace Application.Rides.DTOs
{
    public class AvailableRideDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public byte[] Version { get; set; }
    }
}