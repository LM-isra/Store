using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cannabis.Infrastructure.Data.Context;

public partial class StoreContext : DbContext, IStoreContext
{
    private readonly IConfiguration _config;

    public StoreContext(IConfiguration config) => _config = config;

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}

