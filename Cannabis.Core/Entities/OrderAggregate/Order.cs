
namespace Cannabis.Core.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public Order() { }

    public Order(IReadOnlyList<OrderItem> orderItems, string buyerEamil, Address shipToAddress, DeliveryMethod deliveryMethod,  decimal subtotal)
    {
        BuyerEamil = buyerEamil;
        ShipToAddress = shipToAddress;
        DeliveryMethod = deliveryMethod;
        OrderItems = orderItems;
        Subtotal = subtotal;
    }

    public string BuyerEamil { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public Address ShipToAddress { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; }
    public IReadOnlyList<OrderItem> OrderItems { get; set; }
    public decimal Subtotal { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string PaymentIntentId { get; set; }
    public decimal GetTotal() => Subtotal + DeliveryMethod.Price;
}
