using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.BusinessLogicLayer.ServiceContracts
{
    public interface IProductService
    {
        Task<List<ProductResponse?>> GetProducts();
        Task<List<ProductResponse?>> GetProductsByCondition(Func<Product, bool> conditionExpression);

        Task<ProductResponse?> GetProductByCondition(Func<Product, bool> conditionExpression);
        Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest);

        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);

        Task<bool> DeleteProduct(Guid productID);
    }
}
