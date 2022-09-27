using System.Linq.Expressions;
using Cannabis.Core.Entities.OrderAggregate;

namespace Cannabis.Core.Specifitactions;

public class OrdersWithItemsAndOrderingSpec : BaseSpecification<Order>
{
    public OrdersWithItemsAndOrderingSpec(string email) : base(o => o.BuyerEamil == email)
    {
        AddInclude(o => o.OrderItems);
        AddInclude(o => o.DeliveryMethod);
        AddOrderByDescending(o => o.OrderDate);
    }

    public OrdersWithItemsAndOrderingSpec(int id, string email) 
        : base(o => o.Id == id && o.BuyerEamil == email)
    {
        AddInclude(o => o.OrderItems);
        AddInclude(o => o.DeliveryMethod);
    }
}
