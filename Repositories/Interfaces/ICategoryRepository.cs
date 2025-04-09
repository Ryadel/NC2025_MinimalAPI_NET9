using NC2025_MinimalAPI_NET8.Models;

namespace NC2025_MinimalAPI_NET8.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetCategoryWithProductsAsync(int id);
    }
}
