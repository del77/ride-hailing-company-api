using Core.Domain.Rides;
using Core.Settings;

namespace Core.Services
{
    public interface IRidesService
    {
        void FinishRide(Ride ride, decimal lengthInKilometers);
    }

    public class RidesService : IRidesService
    {
        private readonly RidesSettings _ridesSettings;

        public RidesService(RidesSettings ridesSettings)
        {
            _ridesSettings = ridesSettings;
        }

        public void FinishRide(Ride ride, decimal lengthInKilometers)
        {
            ride.FinishRide(lengthInKilometers, _ridesSettings.CostPerKilometer);
        }
    }
}