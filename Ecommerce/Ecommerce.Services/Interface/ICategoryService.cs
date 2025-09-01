using Ecommerce.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetCategories();
    }
}
