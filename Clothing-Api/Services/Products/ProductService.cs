
using AutoMapper;
using Clothing_Api.Data.Entities;
using Clothing_Api.Data.Repository;
using Clothing_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothing_Api.Services.Products
{
    public class ProductService : IProductService
    {
        private IClothingRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IClothingRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            _productRepository.CreateProduct(productEntity);
            if (await _productRepository.SaveChanges())
            {
                return _mapper.Map<Product>(productEntity);
            }
            throw new Exception("there where and error with the DB");
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            if (await _productRepository.SaveChanges())
                return true;

            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var productsEntity = await _productRepository.GetAllProducts();
            //var commentaries = _reviewService.GetReviews();
            var bookToReturn = _mapper.Map<IEnumerable<Product>>(productsEntity);
            return bookToReturn;
        }

        public async Task<Product> GetProduct(int id)
        {
            var bookEntity = await _productRepository.GetProduct(id);
            if (bookEntity == null)
                throw new Exception("there where and error with the DB");
            var bookToReturn = _mapper.Map<Product>(bookEntity);
            return bookToReturn;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var validate = await _productRepository.GetProduct(id);
            if (validate == null)
                throw new Exception();
            product.Id = id;
            var productEntity = _mapper.Map<ProductEntity>(product);
            _productRepository.UpdateProduct(productEntity);
            if (await _productRepository.SaveChanges())
            {
                return _mapper.Map<Product>(productEntity);
            }
            throw new Exception("there were an error with DB");
        }
    }
}
