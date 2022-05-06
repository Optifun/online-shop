using OnlineShop.Core.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class VendorState
    {
        string[] vendors = new[] {"Razer", "Logitech", "Samsung", "Philips", "Sony"};

        public Task<List<Vendor>> Fetch()
        {
            var products = Enumerable.Range(0, 5).Select(id =>
                new Vendor(id,
                    vendors[id])).ToList();

            return Task.FromResult(products);
        }
    }
}