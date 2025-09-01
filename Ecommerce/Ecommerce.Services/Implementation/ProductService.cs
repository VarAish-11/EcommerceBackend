using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using Ecommerce.Repositories.Interface;
using Ecommerce.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly string _targetFolder = "F:\\Ecommerce Application\\Practice\\src\\assets\\UploadedFiles";
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo) {

            _repo = repo;
        }
        public async Task AddProduct(ProductRequest productRequest,IFormFile file)
        {
            try
            {
                var imageUrl = await AddImage(file);

                Product product = new Product();
                product.Name = productRequest.Name;
                product.Description = productRequest.Description;
                product.StockQuantity = productRequest.StockQuantity;
                product.Price = productRequest.Price;
                product.ImageUrl = imageUrl;
                product.CreatedDate = DateTime.Now;
                product.UpdatedDate = DateTime.Now;

                await _repo.AddProduct(product, productRequest.CategoryId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<List<ProductResponse>> GetAllProduct()
        {
            var data = await _repo.GetAllProduct();
            return data;
        }

        private async Task<string> AddImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("No file Found");
            }

            // Generate a file path
            var filePath = Path.Combine(_targetFolder, file.FileName);

            // Save the file to the target folder
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
