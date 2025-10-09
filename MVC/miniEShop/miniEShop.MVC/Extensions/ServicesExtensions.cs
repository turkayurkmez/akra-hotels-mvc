using Microsoft.EntityFrameworkCore;
using miniEShop.Application.Contracts;
using miniEShop.Application.Services;
using miniEShop.Infrastructure.Data;
using miniEShop.Infrastructure.Repositories;

namespace miniEShop.MVC.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDatabaseResources(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MiniEShopDbContext>(option => { option.UseSqlServer(connectionString); });
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserSevice, UserService>();

            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
           

            return services;

        }
    }
}
