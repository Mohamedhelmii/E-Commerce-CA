using E_Commerce.Core.Entities.OrderAggregate;
using E_Commerce.Core.Entities.ProductAggregate;
using System;
using System.Text.Json;

namespace E_Commerce.Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task  SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = await File.ReadAllTextAsync("../E-Commerce.Repository/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null && brands.Count > 0) { context.ProductBrands.AddRange(brands); }
            }

            if (!context.ProductCategories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync("../E-Commerce.Repository/Data/SeedData/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if (categories != null && categories.Count > 0) { context.ProductCategories.AddRange(categories); }
            }

            if (!context.DeliveryMethods.Any())
            {
                var deliveriesData = await File.ReadAllTextAsync("../E-Commerce.Repository/Data/SeedData/delivery.json");
                var deliveries = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveriesData);
                if (deliveries != null && deliveries.Count > 0) { context.DeliveryMethods.AddRange(deliveries); }
            }

            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../E-Commerce.Repository/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null && products.Count > 0) { context.Products.AddRange(products); }
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
