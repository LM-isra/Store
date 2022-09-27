using AutoMapper;
using Cannabis.Api.Dtos;
using Cannabis.Core.Entities.OrderAggregate;

namespace Cannabis.Api.Helpers;

public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
{

    private readonly IConfiguration _config;
    public OrderItemUrlResolver(IConfiguration config) => _config = config;

    public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        => !string.IsNullOrEmpty(source.ItemOrdered.PictureUrl) ? _config["ApiUrl"] + source.ItemOrdered.PictureUrl : null;
}
