using Ecommerce.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponse>> GetCategories();
    }
}
