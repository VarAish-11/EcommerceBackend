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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult>AddUser(UserRequest user,string role)
        {
            try
            {

                await _authService.AddUser(user,role);
                return Ok(new CommonResponseModel() { Result = "", StatusCode = 200, StatusMessage = "User Added Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CommonResponseModel() { Result = "", StatusCode = 500, StatusMessage = "Error While Adding User" });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Login([FromBody] LoginRequest request)
        {
            try
            {
                var data =await _authService.Login(request);
                return Ok(new CommonResponseModel() { Result = data, StatusCode = 200, StatusMessage = "User data" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CommonResponseModel() { Result = "", StatusCode = 500, StatusMessage = "Error While getting User" });
            }
        }
    }
}
