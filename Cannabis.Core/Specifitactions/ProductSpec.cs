using Cannabis.Core.Entities;

namespace Cannabis.Core.Specifitactions;

public class ProductSpec : BaseSpecification<Product>
{
    public ProductSpec(ProductParams productParams)
        : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.IdBrand.HasValue || x.IdProductBrand == productParams.IdBrand) && 
                (!productParams.IdType.HasValue || x.IdProductType == productParams.IdType))
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
        ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
    }

    public ProductSpec(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}
