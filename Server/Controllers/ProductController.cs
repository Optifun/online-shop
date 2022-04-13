using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO;
using OnlineShop.Server.Services;
using System;
using Product = OnlineShop.Core.Model.Product;

namespace OnlineShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCard>>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return products.Adapt<List<ProductCard>>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCard>> GetProduct(long id)
        {
            var product = await _productRepository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product.Adapt<ProductCard>();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, ProductCard product)
        {
            if (id != product.Id)
                return BadRequest();

            var update = await _productRepository.Update(product.Adapt<Product>());

            if (update == null)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductCard>> PostProduct(ProductInfo product)
        {
            try
            {
                Product created = await _productRepository.Create(product);
                return CreatedAtAction("GetProduct", new {id = created.Id}, created.Adapt<ProductCard>());
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            bool succeed = await _productRepository.Delete(id);
            if (!succeed)
                return NotFound();

            return NoContent();
        }
    }
}