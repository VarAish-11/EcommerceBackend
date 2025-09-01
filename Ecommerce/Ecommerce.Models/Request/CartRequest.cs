using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Request
{
    public class CartRequest
    {
        public int CartId { get; set; } 
        public int UsertId { get; set; }
        public List<CartData> CartData { get; set; }
        
    }

    public class CartData
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
