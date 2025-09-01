using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using Ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddProduct(Product product, int categoryId)
        {
            try
            {
                var category = _db.Category.Find(categoryId);
                if (category != null)
                {
                    product.Category = category;
                    await  _db.Product.AddAsync(product);
                    _db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductResponse>> GetAllProduct()
        {
            var data = await  _db.Product.Include(x=>x.Category).ToListAsync();
            if(data.Any())
            {
                var result = data.Select(x=> new ProductResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    CategoryId = x.Category.Id,
                    ImageUrl = x.ImageUrl,
                }).ToList();

                return result;
            }
            return default;
        }
    }
}
