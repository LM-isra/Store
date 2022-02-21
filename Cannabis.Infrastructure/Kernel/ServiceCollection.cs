using Microsoft.Extensions.DependencyInjection;
using Cannabis.Core.Interfaces.Repositories;
using Cannabis.Infrastructure.Data.Repositories;
using Cannabis.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace Cannabis.Infrastructure.Kernel;

public static class ServiceCollection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStoreContext, StoreContext>();
        services.AddScoped<IStoreFactory, StoreFactory>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services; 
    }
}