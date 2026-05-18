using E_Commerce.APIs.Errors;
using E_Commerce.APIs.Extentions;
using E_Commerce.APIs.Helpers;
using E_Commerce.APIs.Middleware;
using E_Commerce.Core.Services;
using E_Commerce.Repository.Data;
using E_Commerce.Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using System.Reflection;
using System.Threading.Tasks;

namespace E_Commerce.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //    //JSON serializer to ignore object cycles until using DTO
            //    .AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            //}); ;
            builder.Services.AddEndpointsApiExplorer();

            // configure swagger to support XML documentation and param descriptions
            builder.Services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" });

                // كود قراءة ملف الـ XML
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            

            #region move to extension folder

            //// DI of Generic Without using UOW
            //builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            //// Register AutoMapper
            //builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfiles>());
            //// Register Resolver
            //builder.Services.AddScoped<ProductImageUrlSolver>();
            #endregion
            builder.Services.ApplicationServices(builder.Configuration);

            // this configure to standardize validation error response format
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            #region to access data seeding

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreContext>();

            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                await context.Database.MigrateAsync();

                await StoreContextSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during migration or seeding.");
            }
            #endregion
            app.Run();
        }
    }
}
