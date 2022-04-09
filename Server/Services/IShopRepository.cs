using System.Collections.Generic;
using System.Threading.Tasks;
using Shop = OnlineShop.Core.Model.Shop;

namespace OnlineShop.Server.Services
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetAll();
    }
}