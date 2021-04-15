using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Customers.Handlers;
using Application.Services;
using Core.Domain.Coupons;
using Core.Repositories;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace IntegrationTests
{
    public class CustomersTests
    {
        private readonly RideHailingContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDriversRepository _driversRepository;
        private readonly IIdentityProvider _identityProvider;
        
        public CustomersTests()
        {
            _context = InMemoryDatabase.GetContextWithMockedData();
            _unitOfWork = new UnitOfWork(_context);
            _driversRepository = new DriversRepository(_context);
            _identityProvider = new FakeIdentityProvider();
        }
        
        [Fact]
        public async Task Should_Add_Opinion_When_Customer_Provides_it()
        {
            var driver = await _context.Drivers.AsQueryable().FirstOrDefaultAsync();
            var command = new AddOpinionForDriverCommand
            {
                Description = "test description",
                Value = 5,
                DriverId = driver.Id
            };
            IRequestHandler<AddOpinionForDriverCommand, Unit> handler = new AddOpinionForDriverHandler(_unitOfWork, _driversRepository, _identityProvider);
            
            
            var driverOpinionsInitialCount = _context.Opinions.Count(o => o.DriverId == driver.Id);
            await handler.Handle(command, CancellationToken.None);
            var driverOpinionsNewCount = _context.Opinions.Count(o => o.DriverId == driver.Id);

            
            Assert.Equal(driverOpinionsInitialCount + 1, driverOpinionsNewCount);
        }
    }
}