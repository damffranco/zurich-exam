using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zurich.Insurance.Domain.Entities;

namespace Zurich.Infrastructure.Configurations
{
    public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Vehicle");

            builder.Property(b => b.VehicleId)
            .IsRequired();

            builder.Property(b => b.Brend)
            .IsRequired();

            builder.Property(b => b.Model)
            .IsRequired();
        }
    }
}
