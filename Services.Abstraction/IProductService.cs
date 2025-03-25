global using Shared;

namespace Services.Abstraction
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync();
        public Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        public Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync();
        public Task<ProductResultDTO?> GetProductByIdAsync(int ids);
    }
}
