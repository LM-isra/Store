using System.Text.Json;
using Cannabis.Core.Entities;
using Cannabis.Core.Interfaces.Repositories;
using StackExchange.Redis;

namespace Cannabis.Infrastructure.Data.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDatabase _dataBase;

    public BasketRepository(IConnectionMultiplexer redis) =>  _dataBase = redis.GetDatabase();

    public async Task<bool> DeleteBasketAsync(string basketId) => await _dataBase.KeyDeleteAsync(basketId);

    public async Task<CustomerBasket> GetBasketAsync(string basketId)
    {
        var data = await _dataBase.StringGetAsync(basketId);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
        var created = await _dataBase.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
        return !created ?  null :  await GetBasketAsync(basket.Id);
    }
}
