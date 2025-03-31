using Microsoft.EntityFrameworkCore;
using NC2025_MinimalAPI_NET9.Data;
using NC2025_MinimalAPI_NET9.Models;
using NC2025_MinimalAPI_NET9.Repositories.Interfaces;

namespace NC2025_MinimalAPI_NET9.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Category?> GetCategoryWithProductsAsync(int id) =>
            await _dbSet
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}
