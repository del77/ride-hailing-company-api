using System.Threading.Tasks;
using Application.Services;

namespace Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RideHailingContext _context;

        public UnitOfWork(RideHailingContext context)
        {
            _context = context;
        }
        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}