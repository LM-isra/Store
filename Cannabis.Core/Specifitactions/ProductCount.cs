using Cannabis.Core.Entities;

namespace Cannabis.Core.Specifitactions;

public class ProductCount : BaseSpecification<Product>
{
    public ProductCount(ProductParams productParams)
        : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.IdBrand.HasValue || x.IdProductBrand == productParams.IdBrand) && 
                (!productParams.IdType.HasValue || x.IdProductType == productParams.IdType))
    {
        
    }
}
