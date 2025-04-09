using Bogus;
using Microsoft.EntityFrameworkCore;
using NC2025_MinimalAPI_NET8.Models;

namespace NC2025_MinimalAPI_NET8.Data
{
    // Data/DataSeeder.cs

    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var fakerCategory = new Faker<Category>()
                    .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);

                var categories = fakerCategory.Generate(10);
                context.Categories.AddRange(categories);
                context.SaveChanges();

                var fakerProduct = new Faker<Product>()
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
                    .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id);

                var products = fakerProduct.Generate(100);
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
