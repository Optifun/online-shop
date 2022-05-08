using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Price = OnlineShop.Core.Model.Price;
using Product = OnlineShop.Core.Model.Product;

namespace OnlineShop.Server.Services
{
    public interface IProductRepository
    {
        Task<Product?> Get(long id);
        Task<List<Product>> GetAll();
        Task<Product?> Update(Product product);
        Task<Product> Create(ProductInfo product);
        Task Delete(Product product);
        Task<bool> Delete(long id);
        Task<bool> SetPrice(long id, Price price);
    }
}