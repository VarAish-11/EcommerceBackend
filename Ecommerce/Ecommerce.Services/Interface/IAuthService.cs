using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interface
{
    public interface IAuthService
    {
        Task AddUser(UserRequest request, string role);
        Task<UserResponse> Login(LoginRequest request);
    }
}
