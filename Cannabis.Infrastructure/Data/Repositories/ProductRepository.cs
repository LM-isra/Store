using Cannabis.Core.Entities;
using Cannabis.Core.Interfaces.Repositories;
using Cannabis.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cannabis.Infrastructure.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;
    
    public ProductRepository(StoreContext context) => _context = context;

    public async Task<Product> Get(int id) => await _context.Products
        .Include(x => x.ProductType).Include(x => x.ProductBrand).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IReadOnlyList<Product>> Get() =>  await _context.Products
        .Include(x => x.ProductType)
        .Include(x => x.ProductBrand)
        .ToListAsync();

    public async Task<IReadOnlyList<ProductBrand>> GetBrands() => await _context.ProductBrands.ToListAsync();

    public async Task<IReadOnlyList<ProductType>> GetTypes() =>  await _context.ProductTypes.ToListAsync();
}