using System;
using Core.Domain.Customers;
using Core.Domain.Drivers;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace IntegrationTests
{
    public class InMemoryDatabase
    {
        private static DbContextOptions<RideHailingContext> _options;

        public static RideHailingContext GetContextWithMockedData()
        {
            _options = new DbContextOptionsBuilder<RideHailingContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            MockDrivers();
            MockCustomers();
            
            return new RideHailingContext(_options);
        }

        private static void MockDrivers()
        {
            var driver = new Driver("driver1");
            using (var context = new RideHailingContext(_options))
            {
                context.Drivers.Add(driver);

                context.SaveChanges();
            }
        }

        private static void MockCustomers()
        {
            var customer = new Customer(FakeIdentityProvider.TestCustomerId);
            using (var context = new RideHailingContext(_options))
            {
                context.Customers.Add(customer);

                context.SaveChanges();
            }
        }
    }
}