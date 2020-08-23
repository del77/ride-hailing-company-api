using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Rides;
using Core.Interfaces;
using Core.Settings;

namespace Core.Services
{
    public interface IRidesService
    {
        void FinishRide(Ride ride, decimal lengthInKilometers);
        Task<bool> FetchMoneyForRideAsync(Ride ride);
    }

    public class RidesService : IRidesService
    {
        private readonly RidesSettings _ridesSettings;
        private readonly IPaymentService _paymentService;

        public RidesService(RidesSettings ridesSettings, IPaymentService paymentService)
        {
            _ridesSettings = ridesSettings;
            _paymentService = paymentService;
        }

        public void FinishRide(Ride ride, decimal lengthInKilometers)
        {
            ride.FinishRide(lengthInKilometers, _ridesSettings.CostPerKilometer);
        }

        public async Task<bool> FetchMoneyForRideAsync(Ride ride)
        {
            var paymentMethod = ride.Customer.PaymentMethods.First(pm => pm.IsDefault);
            var paymentSuccessful = await _paymentService.FetchMoney(paymentMethod.CardId, ride.Cost!.Value, ride.Cost.Currency);

            if (paymentSuccessful)
                ride.MarkAsPaid();

            return paymentSuccessful;
        }
    }
}