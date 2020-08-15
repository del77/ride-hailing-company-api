using System.Threading.Tasks;
using Core.Domain.Coupons;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly RideHailingContext _context;

        public CouponsRepository(RideHailingContext context)
        {
            _context = context;
        }

        public async Task<Coupon> GetByCodeAsync(string code)
        {
            return await _context.Coupons
                .Include(c => c.CouponUsers)
                .FirstOrDefaultAsync(c => c.Code == code);
        }
    }
}