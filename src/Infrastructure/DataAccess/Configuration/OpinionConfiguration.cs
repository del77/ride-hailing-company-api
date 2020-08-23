using Core.Domain.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration
{
    public class OpinionConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
        }
    }
}