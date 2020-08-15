using System;
using System.Threading.Tasks;
using Core.Domain.Coupons;
using Core.Domain.Rides;
using Core.Repositories;

namespace Core.Factories
{
    public interface IRidesFactory
    {
        Task<Ride> CreateRide(string userId, string address, decimal latitude, decimal longitude, string couponCode);
    }

    public class RidesFactory : IRidesFactory
    {
        private readonly ICouponsRepository _couponsRepository;

        public RidesFactory(ICouponsRepository couponsRepository)
        {
            _couponsRepository = couponsRepository;
        }

        public async Task<Ride> CreateRide(string userId, string address, decimal latitude, decimal longitude,
            string? couponCode)
        {
            Coupon? coupon = null;

            if (couponCode != null)
            {
                coupon = await _couponsRepository.GetByCodeAsync(couponCode);

                if (coupon is null)
                    throw new Exception("Coupon code is invalid");
            }

            return new Ride(userId, address, latitude, longitude, coupon);
        }
    }
}