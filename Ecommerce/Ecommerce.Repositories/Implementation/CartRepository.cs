using Ecommerce.Models.Request;
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
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _db;
        public CartRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddCart(CartRequest request)
        {
            try
            {

                List<CartItem> cartItems = request.CartData.Select(x => new CartItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Product = _db.Product.FirstOrDefault(y => y.Id == x.ProductId),
                    CreatedOn = DateTime.Now,
                    CartItemId = x.CartItemId,
                }).ToList();

                Cart cart = new Cart();
                cart.CreatedOn = DateTime.Now;
                cart.UpdatedOn = DateTime.Now;
                cart.UserId = request.UsertId;
                cart.CartItem = cartItems;
                cart.CartId = request.CartId;
                _db.Cart.Add(cart);
                await _db.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
