using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Request
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int StockQuantity {  get; set; }

        [Required]
        public int CategoryId { get; set; }

        //[Required]
        //public IFormFile ImageUrl { get; set; }
    }
}
