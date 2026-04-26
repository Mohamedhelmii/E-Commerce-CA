using E_Commerce.Core.Entities.OrderAggregate;
using E_Commerce.Core.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Repository.Data.Config
{
    public class OrderItemConfiguration : BaseConfiguration<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);
            builder.Property(oi => oi.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems) 
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne<Product>()
           .WithMany()
           .HasForeignKey(oi => oi.ProductItemId);
        }
    }
}
