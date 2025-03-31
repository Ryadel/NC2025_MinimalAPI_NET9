using NC2025_MinimalAPI_NET9.Models;
using NC2025_MinimalAPI_NET9.Repositories.Interfaces;

namespace NC2025_MinimalAPI_NET9.Endpoints
{
    public static class CategoriesEndpoints
    {
        public static void MapCategoriesEndpoints(this WebApplication app)
        {
            var categoriesGroup = app.MapGroup("/categories");

            categoriesGroup.MapGet("/", async (ICategoryRepository repository) =>
                Results.Ok(await repository.GetAllAsync()));

            categoriesGroup.MapGet("/{id}", async (int id, ICategoryRepository repository) =>
                await repository.GetCategoryWithProductsAsync(id) is Category category
                    ? Results.Ok(category)
                    : Results.NotFound());

            categoriesGroup.MapPost("/", async (Category category, ICategoryRepository repository) =>
            {
                await repository.AddAsync(category);
                return Results.Created($"/categories/{category.Id}", category);
            });
        }
    }
}
