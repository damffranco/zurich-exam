using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zurich.Insurance.Domain.Entities;

namespace Zurich.Infrastructure.Configurations
{
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Customer");
            builder.HasKey(e => e.ExternalId);

            builder.Property(b => b.ExternalId)
            .IsRequired();

            builder.Property(b => b.DocId)
            .IsRequired();

            builder.Property(b => b.Nome)
            .IsRequired();

            builder.Property(b => b.BirthDate)
            .IsRequired();
        }
    }
}
