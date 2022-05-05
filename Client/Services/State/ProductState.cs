using OnlineShop.Core.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class ProductState
    {
        string[] names = new[] {"Мышь Razer H", "Logitech H500", "Мышь Razer M", "Мышь Razer S", "Мышь Razer S+"};
        double[] ratings = new[] {2, 4.5, 4.2, 4.5, 4.9};
        float[] prices = new float[] {860, 2200, 2300, 2600, 3200};
        string[] vendors = new[] {"Razer", "Logitech", "Razer", "Razer", "Razer"};
        Category category = new Category(1, "Компьютерные мыши");

        public Task<List<ProductCard>> FetchCards()
        {
            var products = Enumerable.Range(0, 5).Select(id =>
                new ProductCard(id,
                    names[id],
                    "Some text",
                    ratings[id],
                    new Price(id, prices[id], 0),
                    new Vendor(id, vendors[id]), category)
            ).ToList();

            return Task.FromResult(products);
        }
    }
}