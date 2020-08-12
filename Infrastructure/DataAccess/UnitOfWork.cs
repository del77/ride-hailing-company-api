using System;
using System.Threading.Tasks;
using Application.Services;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ConcurrencyException(e);
            }
        }
    }
}