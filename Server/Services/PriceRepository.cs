using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Server.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Price = OnlineShop.Core.Model.Price;

namespace OnlineShop.Server.Services
{
    public class PriceRepository : IPriceRepository
    {
        private readonly OnlineShopContext _context;

        public PriceRepository(OnlineShopContext context) => 
            _context = context;

        public async Task<List<Price>> GetByProductId(long productId)
        {
            var prices = await _context.Prices
                .Where(price => price.ProductId == productId)
                .ToListAsync();
            
            return prices.Adapt<List<Price>>();
        }

        public async Task<Price?> GetById(long id)
        {
            var price = await _context.Prices.FindAsync(id);
            return price?.Adapt<Price>();
        }
    }
}