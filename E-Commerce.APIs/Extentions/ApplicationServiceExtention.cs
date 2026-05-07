using E_Commerce.APIs.Helpers;
using E_Commerce.Core.Services;
using E_Commerce.Repository.Repository;

namespace E_Commerce.APIs.Extentions
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {

            // DI of Generic Without using UOW
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            // Register AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfiles>());
            // Register Resolver
            services.AddScoped<ProductImageUrlSolver>();

            return services;
        }
    }
}
