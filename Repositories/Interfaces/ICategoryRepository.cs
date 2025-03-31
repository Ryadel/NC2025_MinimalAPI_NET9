using NC2025_MinimalAPI_NET9.Models;

namespace NC2025_MinimalAPI_NET9.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetCategoryWithProductsAsync(int id);
    }
}
