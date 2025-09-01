using Ecommerce.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interface
{
    public interface ICartServices
    {
        Task AddCart(CartRequest request);
    }
}
