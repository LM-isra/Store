using Cannabis.Infrastructure.Data.Context;
using Cannabis.Api.Extensions;
using Cannabis.Api.Middleware;
using Cannabis.Api.Helpers;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;

namespace Cannabis.Api;

public class Startup
{
    private readonly IConfiguration _config;
    public Startup(IConfiguration config) => _config = config;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddControllers();
        services.AddDbContext<StoreContext>(x 
            => x.UseSqlite(_config.GetConnectionString("DefaulConnection")));
        
        services.AddSingleton<IConnectionMultiplexer>(c
            => ConnectionMultiplexer.Connect(ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true)));

        services.AddApplicationServices();
        services.AddSwaggerDocumentation();
        services.AddCors(opt 
            => opt.AddPolicy("CorsPolicy", policy
                => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwaggerDocumentation();
        app.UseStatusCodePagesWithReExecute("/errors/{0}");
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
