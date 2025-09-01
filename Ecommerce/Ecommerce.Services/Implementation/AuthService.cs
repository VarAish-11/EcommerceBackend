using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using Ecommerce.Repositories.Interface;
using Ecommerce.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        public AuthService(IAuthRepository repo)
        {
            _repo = repo;
        }
        public async Task AddUser(UserRequest request, string role)
        {
            try
            {
                User user = new User();
                user.Email = request.Email;
                user.Name = request.Name;
                user.Password = request.Password;
                user.PhoneNumber = request.PhoneNumber;
                user.Address = request.Address;
                user.CreatedOn = DateTime.Now;
                user.UpdatedOn = null;
                await _repo.AddUser(user,role);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        public async Task<UserResponse> Login(LoginRequest request)
        {
            try
            {
                return await _repo.Login(request);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
