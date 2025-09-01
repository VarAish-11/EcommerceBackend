using Ecommerce.Models.Request;
using Ecommerce.Repositories.Interface;
using Ecommerce.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Implementation
{
    public class CartService:ICartServices
    {
        private readonly ICartRepository _repo;
        public CartService(ICartRepository repo)
        {
            _repo = repo;
        }

        public async Task AddCart(CartRequest request)
        {
            try
            {
                await _repo.AddCart(request);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
