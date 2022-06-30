using Cannabis.Core.Entities;
using Cannabis.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cannabis.Api.Controllers;

public class BasketController : BaseApiController
{
    private readonly IBasketRepository _basketRepositoty;

    public BasketController(IBasketRepository basketRepository) => _basketRepositoty = basketRepository;

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
    {
        var basket = await _basketRepositoty.GetBasketAsync(id);
        return Ok(basket ?? new CustomerBasket(id));
    }
    
    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket) => Ok(await _basketRepositoty.UpdateBasketAsync(basket));
    
    [HttpDelete]
    public async Task DeleteBasketAsync(string id) => await _basketRepositoty.DeleteBasketAsync(id);
}
