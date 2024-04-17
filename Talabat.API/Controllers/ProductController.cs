using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications.ProductSpec;

namespace Talabat.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> ProductRepo)
        {
            _productRepo = ProductRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();

            var product = await _productRepo.GetAllWithSpecAsync(spec);

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetAsync(id);

            if (product is null)
                return NotFound(new {Message = "Not Found", StatusCode=404});

            return Ok(product);
        }
    }
}
