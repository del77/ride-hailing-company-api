using System;
using System.Threading.Tasks;
using Core.Domain.Drivers;

namespace Core.Repositories
{
    public interface IDriversRepository
    {
        Task<Driver> GetByIdAsync(string id);
    }
}