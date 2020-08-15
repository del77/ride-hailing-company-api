using System.Threading.Tasks;
using Core.Domain.Customers;

namespace Core.Repositories
{
    public interface ICustomersRepository
    {
        Task AddAsync(Customer customer);
    }
}