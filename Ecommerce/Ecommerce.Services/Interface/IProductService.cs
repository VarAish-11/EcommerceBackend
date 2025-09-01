using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interface
{
    public interface IProductService
    {
        Task AddProduct(ProductRequest productRequest,IFormFile file);
        Task<List<ProductResponse>> GetAllProduct();
    }
}
