using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;
using Shared.Dtos;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {

        [HttpGet( "GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductResultDTO>>> GetAllProducts([FromQuery]ProductParameterSpecifications parameters)
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync(parameters);
            return Ok(products);    
        }

        [HttpGet("GetBrands")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllBrands()
        {
            var brands = await serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("GetTypes")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllTypes()
        {
            var types = await serviceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDTO>> GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }

    }
}
