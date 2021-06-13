using Clothing_Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothing_Api.Data.Repository
{
    public interface IClothingRepository
    {
        Task<bool> SaveChanges();
        Task<ProductEntity> GetProduct(int id);
        void UpdateProduct(ProductEntity product);
        void CreateProduct(ProductEntity product);
        Task DeleteProduct(int id);
        Task<IEnumerable<ProductEntity>> GetAllProducts();
    }
}
