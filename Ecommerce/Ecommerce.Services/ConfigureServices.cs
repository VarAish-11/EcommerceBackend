using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Implementation;
using Ecommerce.Repositories.Interface;
using Ecommerce.Services.Implementation;
using Ecommerce.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Services
{
    public static class ConfigureServices
    {
        public static void RegisteredServices(IServiceCollection services, IConfiguration config)
        {
            //DB
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DbConnection"));
            });

            //Reposiotories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartRepository,CartRepository>();
            services.AddScoped<IAuthService, AuthService>();
           

            //Services
           services.AddScoped<IProductService,ProductService>();
           services.AddScoped<ICategoryService, CategoryService>();
           services.AddScoped<ICartServices, CartService>();
           services.AddScoped<IAuthRepository,AuthRepository>();
        }
    }
}
