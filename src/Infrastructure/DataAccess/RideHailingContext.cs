using System.Reflection;
using Core.Domain.Coupons;
using Core.Domain.Customers;
using Core.Domain.Drivers;
using Core.Domain.Rides;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class RideHailingContext : DbContext
    {
        public RideHailingContext(DbContextOptions<RideHailingContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponCustomer> CouponUsers { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}