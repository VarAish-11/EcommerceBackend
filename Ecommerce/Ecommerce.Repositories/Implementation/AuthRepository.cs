using Ecommerce.Models.Request;
using Ecommerce.Models.Response;
using Ecommerce.Repositories.Entities;
using Ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Implementation
{
    public class AuthRepository: IAuthRepository
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;
        public AuthRepository(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task AddUser(User request,string role)
        {
            try
            {
                var roleData = _db.Roles.FirstOrDefault(x => x.Name == role);
                if (role != null)
                {
                    _db.UserRoles.Add(new UserRole
                    {
                        Role = roleData,
                        User = request
                    });

                    _db.User.Add(request);

                    // Save the changes to the database
                    await _db.SaveChangesAsync();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserResponse> Login(LoginRequest request)
        {
            try
            {
                var user = await(from u in _db.User
                                 join ur in _db.UserRoles
                                 on u.Id equals ur.UserId
                                 join r in _db.Roles
                                 on ur.RoleId equals r.Id
                                 where u.Email == request.Email && u.Password == request.Password
                                 select new UserResponse()
                                 {
                                     Id = u.Id,
                                     Name = u.Name,
                                     Email = u.Email,
                                     Role = r.Name

                                 }).FirstOrDefaultAsync();

                if (user != null)
                {
                    var token = GenerateToken(user);
                    user.Token = token;
                    return user;
                }
                else
                {
                    return new UserResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GenerateToken(UserResponse user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                             new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                             new Claim(JwtRegisteredClaimNames.Email, user.Email),
                             new Claim("Roles", string.Join(",",user.Role)),
                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                             };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                            _config["Jwt:Audience"],
                                            claims,
                                            expires: DateTime.UtcNow.AddMinutes(60), //token expiry minutes
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
