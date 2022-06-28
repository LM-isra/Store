using Cannabis.Core.Entities;

namespace Cannabis.Core.Interfaces.Repositories;

public interface IBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string idBasket);
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string idBasket);
}
