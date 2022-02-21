using Microsoft.EntityFrameworkCore;
using Cannabis.Core.Entities;

namespace Cannabis.Infrastructure.Data.Context;

public interface IStoreContextDbSets
{
    DbSet<Product> Products { get; set; }
    DbSet<ProductBrand> ProductBrands { get; set; }
    DbSet<ProductType> ProductTypes { get; set; }
}