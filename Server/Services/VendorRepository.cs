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

        public async Task<List<Vendor>> GetAll() => 
            await _context.Vendors.ProjectToType<Vendor>().ToListAsync();

        public async Task<Vendor?> Get(long id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            return vendor?.Adapt<Vendor>();
        }
    }
}