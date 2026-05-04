using E_Commerce.Core.Services;
using E_Commerce.Repository.Data;
using E_Commerce.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                //JSON serializer to ignore object cycles until using DTO
                .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            }); ;
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(
                option =>
                {
                    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });


            // DI of Generic Without using UOW
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            var app = builder.Build();

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
