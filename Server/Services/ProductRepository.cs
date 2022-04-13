using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Core.DTO;
using OnlineShop.Server.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Category = OnlineShop.Core.Model.Category;
using Price = OnlineShop.Core.Model.Price;
using Product = OnlineShop.Core.Model.Product;
using Vendor = OnlineShop.Core.Model.Vendor;

namespace OnlineShop.Server.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IVendorRepository _vendorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPriceRepository _priceRepository;

        public ProductRepository(OnlineShopContext context,
            IVendorRepository vendorRepository,
            ICategoryRepository categoryRepository,
            IPriceRepository priceRepository)
        {
            _vendorRepository = vendorRepository;
            _categoryRepository = categoryRepository;
            _priceRepository = priceRepository;
            _context = context;
        }

        public async Task<Product?> Get(long id)
        {
            var product = await _context.Products.FindAsync(id);
            return product?.Adapt<Product>();
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products.Adapt<List<Product>>();
        }

        public async Task<Product?> Update(Product product)
        {
            if (!ProductExists(product.Id)) return null;
            DataAccess.Product entry = product.Adapt<DataAccess.Product>();

            _context.Entry(entry).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Create(ProductInfo product)
        {
            var (price, vendor, category) = await FetchDependencies(product);

            var entityEntry = _context.Products.Add(product.Adapt<DataAccess.Product>());
            await _context.SaveChangesAsync();

            price.ProductId = entityEntry.Entity.Id;
            await _context.SaveChangesAsync();

            Product newProduct = entityEntry.Entity.Adapt<Product>();
            newProduct.Category = category;
            newProduct.Vendor = vendor;
            newProduct.Price = price.Adapt<Price>();
            
            return newProduct;
        }

        public async Task Delete(Product product)
        {
            var p = await _context.Products.FindAsync(product.Id);
            if (p == null)
                return;

            await RemoveProduct(p);
        }

        public async Task<bool> Delete(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            await RemoveProduct(product);
            return true;
        }

        private async Task RemoveProduct(DataAccess.Product p)
        {
            _context.Products.Remove(p);
            await _context.SaveChangesAsync();
        }

        private async Task<(DataAccess.Price, Vendor, Category)> FetchDependencies(ProductInfo product)
        {
            var price = await _priceRepository.CreateRaw(new Price() {Value = product.Price});
            var vendor = await _vendorRepository.Get(product.VendorId);
            var category = await _categoryRepository.Get(product.CategoryId);

            if (vendor == null || price == null || category == null)
                throw new ArgumentException("Wrong vendor or category id", nameof(product));
            return (price, vendor, category);
        }

        private bool ProductExists(long id) =>
            _context.Products.Any(e => e.Id == id);
    }
}