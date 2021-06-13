using Clothing_Api.Models;
using Clothing_Api.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothing_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception)
            {

                throw new Exception("there where and error with the DB");
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                return Ok(product);
            }
            catch (Exception)
            {
                throw new Exception("there where and error with the DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postedProduct = await this._productService.CreateProduct(product);
            return Ok(postedProduct);
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            try
            {
                return Ok(await this._productService.UpdateProduct(id, product));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                return Ok(await this._productService.DeleteProduct(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
    }
}
