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
    public class VendorController : Controller
    {
        private readonly IVendorRepository _vendorRepository;


        public VendorController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Vendor>> Index()
        {
            var vendors = await _vendorRepository.GetAll();
            return Ok(vendors.Adapt<List<Vendor>>());
        }
    }


}