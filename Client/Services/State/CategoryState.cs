using OnlineShop.Core.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class CategoryState
    {
        string[] category = new[] {"Телевизоры", "Компьютерные мыши", "Мониторы", "Видеопроигрыватели"};

        public Task<List<Category>> Fetch()
        {
            var categories = Enumerable.Range(0, 4).Select(id =>
                new Category(id,
                    category[id])).ToList();
            
            return Task.FromResult(categories);
        }
    }
}