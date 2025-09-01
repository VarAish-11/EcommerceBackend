using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Interface
{
    public  interface IProductRepository
    {
        Task AddProduct(Product product,int categoryId);
        Task<List<ProductResponse>> GetAllProduct();
    }
}
