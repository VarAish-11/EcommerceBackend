using Ecommerce.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Interface
{
    public interface ICartRepository
    {
        Task AddCart(CartRequest request);
    }
}
