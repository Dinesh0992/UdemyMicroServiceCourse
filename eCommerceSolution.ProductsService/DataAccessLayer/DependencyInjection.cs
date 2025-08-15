using eCommerce.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.DataAccessLayer.RepositoryContracts;
using eCommerce.DataAccessLayer.Repositories;

namespace eCommerce.ProductService.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services,IConfiguration configuration)
        {
            // TO DO : Register your data access layer services here

            string connectionStringTemplate = configuration.GetConnectionString("DefaultConnection")!;

          string connectionString=  connectionStringTemplate.Replace("$MYSQL_HOST",Environment.GetEnvironmentVariable("MYSQL_HOST")??"localhost")
                                    .Replace("$MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD")??"admin");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(connectionString);
            });
            // Register repositories
            services.AddScoped<IProductsRepository,ProductsRepository>();
            return services;
        }
    }
}
