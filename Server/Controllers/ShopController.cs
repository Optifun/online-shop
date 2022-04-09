using Mapster;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO;
using OnlineShop.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        private readonly IShopRepository _shopRepository;
        
        public ShopController(IShopRepository shopRepository) => 
            _shopRepository = shopRepository;

        [HttpGet]
        public async Task<ActionResult<Shop>> Index()
        {
            var shops = await _shopRepository.GetAll();
            return Ok(shops.Adapt<List<Shop>>());
        }
    }
}