using System.Collections.Generic;
using System.Threading.Tasks;
using Price = OnlineShop.Core.Model.Price;

namespace OnlineShop.Server.Services
{
    public interface IPriceRepository
    {
        Task<List<Price>> GetByProductId(long productId);

        Task<Price?> GetById(long id);
        Task<Price> Create(Price price);
        Task<DataAccess.Price> CreateRaw(Price price);
    }
}