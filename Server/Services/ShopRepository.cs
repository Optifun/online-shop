using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Server.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop = OnlineShop.Core.Model.Shop;

namespace OnlineShop.Server.Services
{
    public class ShopRepository : IShopRepository
    {
        private OnlineShopContext _context;

        public ShopRepository(OnlineShopContext context)
        {
            _context = context;
        }

        public async Task<List<Shop>> GetAll()
        {
            List<DataAccess.Shop> listAsync = await _context.Shops.ToListAsync();
            return listAsync.Adapt<List<Shop>>();
        }
    }
}