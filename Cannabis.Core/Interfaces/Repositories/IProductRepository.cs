using Cannabis.Core.Entities;

namespace Cannabis.Core.Interfaces.Repositories;
public interface IProductRepository
{
    Task<Product> Get(int id);
    Task<IReadOnlyList<Product>> Get();
    Task<IReadOnlyList<ProductBrand>> GetBrands();
    Task<IReadOnlyList<ProductType>> GetTypes();
}
