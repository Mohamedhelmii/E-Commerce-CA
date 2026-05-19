using E_Commerce.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Repository.Data.Config
{
    public class OrderConfiguration : BaseConfiguration<Order>
    {
        // This method is to show that the address is part of the order class and (a.withowner) it can only exist if it carries the order.
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);    
            builder.OwnsOne(o => o.ShipToAddress, a => { a.WithOwner(); });

            // To tell him that the status appears with names (pending, Received, Failed) not (0, 1, 2)
            builder.Property(s => s.Status)
                .HasConversion(oStatus => oStatus.ToString(), ostatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), ostatus));

            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.DeliveryMethod)
               .WithMany(o =>o.Orders)
               .HasForeignKey(o => o.DeliveryMethodId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(o => o.Subtotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
