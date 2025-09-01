using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Entities
{
    public  class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartId { get; set; } 
        public DateTime CreatedOn { get; set;}
        public DateTime UpdatedOn { get; set;}
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<CartItem> CartItem { get; set; }
        
    }
}
