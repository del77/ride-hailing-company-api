using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Coupons;
using Core.Domain.Rides;
using Core.Exceptions;
using Core.Repositories;

namespace Core.Factories
{
    public interface IRideFactory
    {
        Task<Ride> CreateRideAsync(string customerId, string address, decimal latitude, decimal longitude, string couponCode);
    }
    
    public class RideFactory : IRideFactory
    {
        private readonly ICouponsRepository _couponsRepository;
        private readonly ICustomersRepository _customersRepository;

        public RideFactory(ICouponsRepository couponsRepository, ICustomersRepository customersRepository)
        {
            _couponsRepository = couponsRepository;
            _customersRepository = customersRepository;
        }
        
        public async Task<Ride> CreateRideAsync(string customerId, string address, decimal latitude, decimal longitude, string? couponCode)
        {
            var customer = await _customersRepository.GetAsync(customerId);

            var existsUnpaidRideForCustomer = customer.Rides.Any(r => !r.IsPaid);
            if(existsUnpaidRideForCustomer)
                throw new ExistsUnpaidRideException(customerId);

            var customerDoesNotHavePaymentMethod = !customer.PaymentMethods.Any();
            if(customerDoesNotHavePaymentMethod)
                throw new NoPaymentMethodException(customerId);
            
            Coupon? coupon = null;
            if (couponCode != null)
            {
                coupon = await _couponsRepository.GetByCodeAsync(couponCode);
                
                if(coupon is null)
                    throw new Exception("Coupon code is invalid");
            }
            
            return new Ride(customerId, address, latitude, longitude, coupon);
        }
    }
}