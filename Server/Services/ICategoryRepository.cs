using System.Collections.Generic;
using System.Threading.Tasks;
using Category = OnlineShop.Core.Model.Category;

namespace OnlineShop.Server.Services
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> Get(long id);
    }
}