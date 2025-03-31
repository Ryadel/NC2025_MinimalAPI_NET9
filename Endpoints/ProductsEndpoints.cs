using NC2025_MinimalAPI_NET9.Models;
using NC2025_MinimalAPI_NET9.Repositories.Interfaces;

namespace NC2025_MinimalAPI_NET9.Endpoints
{
    public static class ProductsEndpoints
    {
        public static void MapProductsEndpoints(this WebApplication app)
        {
            var productsGroup = app.MapGroup("/products");

            productsGroup.MapGet("/", async (IRepository<Product> repository) =>
            {
                return Results.Ok(await repository.GetAllAsync());
            });

            productsGroup.MapGet("/{id}", async (int id, IRepository<Product> repository) =>
            {
                var product = await repository.GetByIdAsync(id);
                return product != null ? Results.Ok(product) : Results.NotFound();
            });

            productsGroup.MapPost("/", async (Product product, IRepository<Product> repository) =>
            {
                await repository.AddAsync(product);
                return Results.Created($"/products/{product.Id}", product);
            });

            productsGroup.MapPut("/{id}", async (int id, Product product, IRepository<Product> repository) =>
            {
                var existingProduct = await repository.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    return Results.NotFound();
                }
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                await repository.UpdateAsync(existingProduct);
                return Results.NoContent();
            });

            productsGroup.MapDelete("/{id}", async (int id, IRepository<Product> repository) =>
            {
                var existingProduct = await repository.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    return Results.NotFound();
                }
                await repository.DeleteAsync(id);
                return Results.NoContent();
            });
        }
    }
}
