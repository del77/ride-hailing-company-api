using Core.Domain.Rides;

namespace Application.Rides.DTOs
{
    public class AvailableRideDto
    {
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}