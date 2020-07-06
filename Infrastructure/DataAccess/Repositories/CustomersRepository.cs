using System.Threading.Tasks;
using Core.Domain.Customers;
using Core.Repositories;

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
    }
}