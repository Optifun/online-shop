using Mapster;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO;
using OnlineShop.Server.Services;
using System.Threading.Tasks;


namespace OnlineShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public PriceController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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