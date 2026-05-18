using E_Commerce.APIs.Helpers;
using E_Commerce.Core.Services;
using E_Commerce.Repository.Data;
using E_Commerce.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace E_Commerce.APIs.Extentions
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(
                option =>
                {
                    option.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                });
            // DI of Generic Without using UOW
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            // Register AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfiles>());
            // Register Resolver
            services.AddScoped<ProductImageUrlSolver>();
            // configure Redis connection and register BasketRepository in DI
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(config.GetConnectionString("Redis")!, true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            services.AddScoped<IBasketRepo, BasketRepo>();
            return services;
        }
    }
}
