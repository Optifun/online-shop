using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Server.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using Category = OnlineShop.Core.Model.Category;

namespace OnlineShop.Server.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineShopContext _context;

        public CategoryRepository(OnlineShopContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Adapt<List<Category>>();
        }

        public async Task<Category> Get(long id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category.Adapt<Category>();
        }
    }
}