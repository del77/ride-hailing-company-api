using System;
using System.Threading.Tasks;
using Core.Domain.Drivers;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class DriversRepository : IDriversRepository
    {
        private readonly RideHailingContext _context;

        public DriversRepository(RideHailingContext context)
        {
            _context = context;
        }
        
        public async Task<Driver> GetByIdAsync(string id)
        {
            return await _context.Drivers
                .Include(x => x.Rides)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}