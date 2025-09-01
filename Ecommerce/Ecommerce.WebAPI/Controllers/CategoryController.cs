using Ecommerce.Models.Response;
using Ecommerce.Services.Implementation;
using Ecommerce.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var data = await _categoryService.GetCategories();
            if (data.Any())
            {
                return Ok(new CommonResponseModel() { Result = data, StatusCode = 200, StatusMessage = "Result" });
            }
            return Ok(new CommonResponseModel() { Result = "", StatusCode = 200, StatusMessage = "No Data Found" });
        }
    }
}
