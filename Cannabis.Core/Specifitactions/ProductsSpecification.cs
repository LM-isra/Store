using System.Linq.Expressions;
using Cannabis.Core.Entities;

namespace Cannabis.Core.Specifitactions;

public class ProductsSpecification : BaseSpecification<Product>
{
    public ProductsSpecification()
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }

    public ProductsSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}
