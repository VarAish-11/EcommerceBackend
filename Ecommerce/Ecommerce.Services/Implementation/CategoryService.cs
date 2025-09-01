using Ecommerce.Models.Response;
using Ecommerce.Repositories.Interface;
using Ecommerce.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<CategoryResponse>> GetCategories()
        {
            return await _repo.GetCategories();
        }
    }
}
