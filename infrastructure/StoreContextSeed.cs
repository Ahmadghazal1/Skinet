using System.Text.Json;
using Core.Entities;
using infrastructure.Data;

namespace infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext)
        {

            if (!storeContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                storeContext.ProductBrands.AddRange(brands);
            }

            if (!storeContext.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                storeContext.ProductTypes.AddRange(types);
            }

            if (!storeContext.Products.Any())
            {
                var productsData = File.ReadAllText("../infrastructure/Data/SeedData/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(productsData);
                storeContext.Products.AddRange(Products);
            }

            if (storeContext.ChangeTracker.HasChanges()) await storeContext.SaveChangesAsync();
        }
    }
}