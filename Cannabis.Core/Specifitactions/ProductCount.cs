using Cannabis.Core.Entities;

namespace Cannabis.Core.Specifitactions;

public class ProductCount : BaseSpecification<Product>
{
    public ProductCount(ProductParams productParams)
        : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
    {
        
    }
}
