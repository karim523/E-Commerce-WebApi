global using AutoMapper;
global using Domain.Contracts;
global using Domain.Entities;
global using Shared;
using Services.Specifications;

namespace Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {

        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var brandsResult = _mapper.Map<IEnumerable<BrandResultDTO>>(brands);

            return brandsResult;
        }

        public async Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(
                new ProductWithBrandAndTypeSpecifications());

            var productsResult = _mapper.Map<IEnumerable<ProductResultDTO>>(products);

            return productsResult;
        }

        public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            
            var typesResult = _mapper.Map<IEnumerable<TypeResultDTO>>(types);

            return typesResult;
        }

        public async Task<ProductResultDTO?> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(
                new ProductWithBrandAndTypeSpecifications(id));

            if (product is not null)
                return _mapper.Map<ProductResultDTO>(product);
       

            return null;

        }
    }
}
