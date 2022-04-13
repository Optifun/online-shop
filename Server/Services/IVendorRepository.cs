using OnlineShop.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Server.Services
{
    public interface IVendorRepository
    {
        Task<List<Vendor>> GetAll();
        Task<Vendor?> Get(long id);
    }
}