﻿using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastructure
{

    public static  class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services  to the dependency  injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services )
        {
            //To DO : Add services  to the IOC container 
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
