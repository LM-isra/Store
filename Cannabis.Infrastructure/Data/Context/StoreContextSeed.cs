using System.Text.Json;
using Cannabis.Core.Entities;
using Microsoft.Extensions.Logging;

namespace Cannabis.Infrastructure.Data.Context;

public class StoreContextSeed 
{
    public static async Task SeedAsync(IStoreContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if(!context.ProductBrands.Any())
            {
                var brandsJson = await File.ReadAllTextAsync("..\\Cannabis.Infrastructure\\Data\\SeedData\\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsJson);
                await context.ProductBrands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }

            if(!context.ProductTypes.Any())
            {
                var typesJson = await File.ReadAllTextAsync("..\\Cannabis.Infrastructure\\Data\\SeedData\\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesJson);
                await context.ProductTypes.AddRangeAsync(types);
                await context.SaveChangesAsync();
            }

            if(!context.Products.Any())
            {
                var productsJson = await File.ReadAllTextAsync("..\\Cannabis.Infrastructure\\Data\\SeedData\\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsJson);
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
        catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<StoreContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}