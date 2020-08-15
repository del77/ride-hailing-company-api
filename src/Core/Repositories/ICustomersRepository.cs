using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Customers;
using Core.Domain.Rides;

namespace Core.Repositories
{
    public interface ICustomersRepository
    {
        Task AddAsync(Customer customer);
        Task<bool> ExistsUnpaidRideForCustomerAsync(string userId);
        Task<IEnumerable<Ride>> GetUnpaidRidesAsync(string customerId);
        Task<Customer> GetAsync(string customerId);
    }
}