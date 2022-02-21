using Cannabis.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cannabis.Infrastructure.Data.Context;

public partial class StoreContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
}

