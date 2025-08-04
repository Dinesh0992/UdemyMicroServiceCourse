using eCommerce.BusinessLogicLayer.Services;
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.Mappers;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using eCommerce.BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


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
            services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);
            services.AddScoped<IProductsService, ProductsService>();
            return services;
        }
    }
}
  