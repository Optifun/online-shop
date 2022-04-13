using Mapster;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO;
using OnlineShop.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Server.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Index()
        {
            var categories = await _categoryRepository.GetAll();
            return categories.Adapt<List<Category>>();
        }
    }
}