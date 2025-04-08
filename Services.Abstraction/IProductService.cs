global using Shared;
using Shared.Dtos;

namespace Services.Abstraction
{
    public interface IProductService
    {
        public Task<PaginatedResult<ProductResultDTO>> GetAllProductsAsync(ProductParameterSpecifications parameters);
        public Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        public Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync();
        public Task<ProductResultDTO?> GetProductByIdAsync(int ids);
    }
}
