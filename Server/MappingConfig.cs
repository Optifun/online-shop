using Mapster;
using OnlineShop.Core.Model;
using System.Linq;

namespace OnlineShop.Server
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<DataAccess.Product, Product>()
                .Map(nameof(Product.Rating), prod => prod.Reviews.Count > 0 ? prod.Reviews.Average(rev => rev.Rating) : 0);
            // .Map(product => product.Price, product => product.Price)
            // .Map(product => product.Vendor, product => product.Vendor)
            // .Map(product => product.Category, product => product.Category);

            // .MapToTargetWith((db, product1) => new Product()
            // {
            //     Id = db.Id,
            //     Name = db.Name,
            //     Description = db.Description,
            //     Price = db.Price.Adapt<Price>(),
            //     Category = db.Category.Adapt<Category>(),
            //     Vendor = db.Vendor.Adapt<Vendor>(),
            //     Rating = db.Reviews.Average(rev => rev.Rating),
            //     ProductShops = db.ProductShops.Adapt<List<ProductAmmount>>()
            // });
            // .AfterMapping((db, model) => model.Rating = db.Reviews.Average(rev => rev.Rating));
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     Price = product.Price.Adapt<DataAccess.Price>(),
            //     Category = product.Category.Adapt<DataAccess.Category>(),
            //     Vendor = product.Vendor.Adapt<DataAccess.Vendor>(),
            //     PriceId = product.Price.Id,
            //     CategoryId = product.Category.Id,
            //     VendorId = product.Vendor.Id
            // }, product => new Product()
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     Price = product.Price.Adapt<Price>(),
            //     Category = product.Category.Adapt<Category>(),
            //     Vendor = product.Vendor.Adapt<Vendor>(),
            //     Rating = product.Reviews.Average(rev => rev.Rating),
            //     ProductShops = product.ProductShops.Adapt<List<ProductAmmount>>()
            // });
        }
    }
}