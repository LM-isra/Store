using Cannabis.Core.Interfaces.Repositories;
using Cannabis.Infrastructure.Data.Repositories;
using Cannabis.Infrastructure.Data.Context;
using Cannabis.Api.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Cannabis.Api.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStoreFactory, StoreFactory>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.Configure<ApiBehaviorOptions>(options => {
            options.InvalidModelStateResponseFactory = actionContext => 
                new BadRequestObjectResult(new ApiValidationErrorResponse
                {
                    Errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray()
                });
            });

        return services; 
    }
}
