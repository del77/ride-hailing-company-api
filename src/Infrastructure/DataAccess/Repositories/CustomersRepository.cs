using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Customers;
using Core.Domain.Rides;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly RideHailingContext _context;

        public CustomersRepository(RideHailingContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.AddAsync(customer);
        }

        public async Task<bool> ExistsUnpaidRideForCustomerAsync(string userId)
        {
            return await _context.Rides
                .AnyAsync(r => r.CustomerId == userId && !r.IsPaid);
        }

        public async Task<IEnumerable<Ride>> GetUnpaidRidesAsync(string customerId)
        {
            return await _context.Rides.Where(r => r.CustomerId == customerId && r.IsPaid).ToListAsync();
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            return await _context.Customers
                .Include(c => c.PaymentMethods)
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}