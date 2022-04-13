using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                .ProjectToType<Price>()
                .ToListAsync();

            return prices;
        }

        public async Task<Price?> GetById(long id)
        {
            var price = await _context.Prices.FindAsync(id);
            return price?.Adapt<Price>();
        }

        public async Task<Price> Create(Price price)
        {
            var p = await CreateRaw(price);
            
            return p.Adapt<Price>();
        }

        public async Task<DataAccess.Price> CreateRaw(Price price)
        {
            var entry = _context.Prices.Add(price.Adapt<DataAccess.Price>());
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}