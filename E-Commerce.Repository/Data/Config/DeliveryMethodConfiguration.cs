using E_Commerce.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Repository.Data.Config
{
    public class DeliveryMethodConfiguration : BaseConfiguration<DeliveryMethod>
    {
        public override void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            base.Configure(builder);
            builder.Property(d => d.Price).HasColumnType("decimal(18,2)");
        }
    }
}
