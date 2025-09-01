using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Entities
{
    public class Product
    {
        public Product()
        {
            CartItems = new List<CartItem>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }    
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set;}

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
