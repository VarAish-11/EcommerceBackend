using Ecommerce.Models.Response;
using Ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db) {
            _db = db;
        }
        public async Task<List<CategoryResponse>> GetCategories()
        {
            var data= await _db.Category.ToListAsync();
            if(data.Any())
            {
                var result = data.Select(x=> new CategoryResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

                return result;
            }
            return default;
        }
    }
}
