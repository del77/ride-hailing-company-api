using Core.Domain.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(d => d.IdentityId)
                .IsRequired();

            builder.OwnsOne(d => d.Vehicle);

            builder.HasMany(d => d.Opinions)
                .WithOne()
                .HasForeignKey(d => d.DriverId)
                .IsRequired();
        }
    }
}