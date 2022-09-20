using AutoMapper;
using Cannabis.Api.Dtos;
using Cannabis.Core.Entities;
using Cannabis.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cannabis.Api.Controllers;

public class BasketController : BaseApiController
{
    private readonly IBasketRepository _basketRepositoty;
    private readonly IMapper _mapper;

    public BasketController(IBasketRepository basketRepository, IMapper mapper) 
    {
        _basketRepositoty = basketRepository;
        _mapper = mapper;
    } 

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
    {
        var basket = await _basketRepositoty.GetBasketAsync(id);
        return Ok(basket ?? new CustomerBasket(id));
    }
    
    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket) 
    {
        var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
        var update = await _basketRepositoty.UpdateBasketAsync(customerBasket);
        return Ok(update);
    } 
    
    [HttpDelete]
    public async Task DeleteBasketAsync(string id) => await _basketRepositoty.DeleteBasketAsync(id);
}
