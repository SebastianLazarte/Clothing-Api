using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clothing_Api.Data.Entities;
using Clothing_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Clothing_Api.Data.Repository
{
    public class ClothingRepository : IClothingRepository
    {
        private ClothingDbContext _clothingDbContext;
        private List<Product> _products = new List<Product>();
        public ClothingRepository(ClothingDbContext clothingDbContext)
        {
            _clothingDbContext = clothingDbContext;
        }
        public void CreateProduct(ProductEntity product)
        {
            _clothingDbContext.Products.Add(product);
        }

        public async Task DeleteProduct(int id)
        {
            var bookToDelete = await _clothingDbContext.Products.SingleAsync(a => a.Id == id);
            _clothingDbContext.Products.Remove(bookToDelete);
        }

        public async Task<ProductEntity> GetProduct(int id)
        {
            IQueryable<ProductEntity> query = _clothingDbContext.Products;
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _clothingDbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateProduct(ProductEntity product)
        {
            _clothingDbContext.Products.Update(product);
        }

        public Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            IEnumerable<ProductEntity> Products = _clothingDbContext.Products;
            return Task.FromResult(Products);
        }
    }

}