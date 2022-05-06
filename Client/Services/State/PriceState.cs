using OnlineShop.Core.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class PriceState
    {
        public Task<List<Price>> Fetch(long productId)
        {
            var prices = Enumerable.Range(0, 8).Select(id =>
                new Price(id * productId, id * 53.24f, 0.2f)).ToList();

            return Task.FromResult(prices);
        }
    }
}