using Cannabis.Core.Entities;
using Cannabis.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Cannabis.Infrastructure.Data.Context;

public partial class StoreContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
}

