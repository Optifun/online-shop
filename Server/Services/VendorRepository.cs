using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Server.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor = OnlineShop.Core.Model.Vendor;

namespace OnlineShop.Server.Services
{
    public class VendorRepository : IVendorRepository
    {
        private readonly OnlineShopContext _context;

        public VendorRepository(OnlineShopContext context) =>
            _context = context;

        public async Task<List<Vendor>> GetAll()
        {
            List<DataAccess.Vendor> listAsync = await _context.Vendors.ToListAsync();
            return listAsync.Adapt<List<Vendor>>();
        }
    }
}