using Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.IdentityId)
                .IsRequired();

            builder.HasMany(c => c.PaymentMethods)
                .WithOne()
                .HasForeignKey(pm => pm.CustomerId);
        }
    }
}