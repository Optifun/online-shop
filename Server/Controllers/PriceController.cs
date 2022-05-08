using Mapster;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO;
using OnlineShop.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OnlineShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IPriceRepository _priceRepository;

        public PriceController(IProductRepository productRepository, IPriceRepository priceRepository)
        {
            _productRepository = productRepository;
            _priceRepository = priceRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Price>>> Get(long id)
        {
            var prices = await _priceRepository.GetByProductId(id);
            if (prices.Count > 0)
                return Ok(prices);
            else
                return NotFound("Product does not exist");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] Price price)
        {
            bool succeed = await _productRepository.SetPrice(id, price.Adapt<Core.Model.Price>());
            if (succeed)
                return Ok();
            else
                return BadRequest("Product could not be found");
        }
    }
}