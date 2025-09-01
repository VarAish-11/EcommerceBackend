using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using Ecommerce.Services.Implementation;
using Ecommerce.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        [HttpPost]
        public async Task<IActionResult>AddCart(CartRequest request)
        {
            try
            {

                await _cartServices.AddCart(request);
                return Ok(new CommonResponseModel() { Result = "", StatusCode = 200, StatusMessage = "Cart Added Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CommonResponseModel() { Result = "", StatusCode = 500, StatusMessage = "Error While Adding Cart" });
            }
        }
    }
}
