using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zurich.Insurance.Domain;

namespace Zurich.Infrastructure.Configurations
{
    public sealed class InsuranceConfiguration : IEntityTypeConfiguration<Insurance.Domain.Entities.Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance.Domain.Entities.Insurance> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Insurance");
            builder.HasKey(e => e.InsuranceId);
            builder.Ignore(i => i.CommercialPrize);
            builder.Ignore(i => i.PurePrize);
            builder.Ignore(i => i.RiskPrize);
            builder.Ignore(i => i.RiskRate);

            builder.Property(b => b.InsuranceId)
            .IsRequired();

            builder.Property(b => b.VehiclePrize)
            .IsRequired();

            builder.Property(b => b.VehicleId)
            .IsRequired();

            builder.Property(b => b.CustomerExternalId)
            .IsRequired();

            builder.HasOne(b => b.Vehicle)
           .WithMany()
           .HasForeignKey(c => c.VehicleId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Customer)
            .WithMany()
            .HasForeignKey(c => c.CustomerExternalId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
