using Clothing_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothing_Api.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<Product> UpdateProduct(int id, Product product);
        Task<Product> CreateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
