using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using Ecommerce.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]ProductRequest product, IFormFile file)
        {
            try
            {
                
                await _productService.AddProduct(product,file);
                return Ok(new CommonResponseModel() { Result = "", StatusCode = 200, StatusMessage = "Product Added Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CommonResponseModel() { Result = "", StatusCode = 500, StatusMessage = "Error While Adding Product" });
            }
        }

        [HttpGet]
        public async Task<IActionResult>GetAllProduct()
        {
            var data = await _productService.GetAllProduct();
            if(data.Any())
            {
                return Ok(new CommonResponseModel() { Result = data, StatusCode = 200, StatusMessage = "Result" });
            }
            return Ok(new CommonResponseModel() { Result = "", StatusCode = 200, StatusMessage = "No Data Found" });
        }
    }
}
