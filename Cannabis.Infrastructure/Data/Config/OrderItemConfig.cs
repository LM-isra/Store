using Cannabis.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cannabis.Infrastructure.Data.Config;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    void IEntityTypeConfiguration<OrderItem>.Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.OwnsOne(i => i.ItemOrdered, io => io.WithOwner());

        builder.Property(i => i.Price)
            .HasColumnType("decimal(18,2)");
    }
}
