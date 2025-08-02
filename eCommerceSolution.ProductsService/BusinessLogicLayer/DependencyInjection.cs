using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ProductService.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            // TO DO : Register your business logic layer services here
            // Register FluentValidation validators
            services.AddScoped<IValidator<ProductAddRequest>, ProductAddRequestValidator>();
            services.AddScoped<IValidator<ProductUpdateRequest>, ProductUpdateRequestValidator>();
            return services;
        }
    }
}
