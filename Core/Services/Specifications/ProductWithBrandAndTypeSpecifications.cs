namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : Specifications<Product>
    {
        public ProductWithBrandAndTypeSpecifications(int id)
            : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }

        public ProductWithBrandAndTypeSpecifications(ProductParameterSpecifications parameters)
            : base(product =>
                 (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
                 (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
            if (parameters.Sort is not null)
            {
                switch (parameters.Sort)
                {
                    case ProductSortOptions.PriceDesc:
                        SetOrderByDescending(p => p.Price);
                        break;
                    case ProductSortOptions.PriceAsc:
                        SetOrderBy(p => p.Price);
                        break;
                    case ProductSortOptions.NameDesc:
                        SetOrderByDescending(p => p.Name);
                        break;
                    default:
                        SetOrderBy(p => p.Name);
                        break;
                }
            }
            ApplyPagination(parameters.PageIndex,parameters.PageSize);
        }

    }
}
