using System.Threading.Tasks;
using Core.Domain.Coupons;

namespace Core.Repositories
{
    public interface ICouponsRepository
    {
        Task<Coupon> GetByCodeAsync(string code);
    }
}