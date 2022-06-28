using System.Text.Json;
using Cannabis.Core.Entities;
using Cannabis.Core.Interfaces.Repositories;
using StackExchange.Redis;

namespace Cannabis.Infrastructure.Data.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDatabase _dataBase;

    public BasketRepository(IConnectionMultiplexer redis) =>  _dataBase = redis.GetDatabase();

    public async Task<bool> DeleteBasketAsync(string id) => await _dataBase.KeyDeleteAsync(id);

    public async Task<CustomerBasket> GetBasketAsync(string id)
    {
        var data = await _dataBase.StringGetAsync(id);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
        var created = await _dataBase.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
        return !created ?  null :  await GetBasketAsync(basket.Id);
    }
}
