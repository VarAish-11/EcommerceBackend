using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Entities
{
    public  class CartItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
