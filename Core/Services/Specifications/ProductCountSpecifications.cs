namespace Services.Specifications
{
    public class ProductCountSpecifications : Specifications<Product>
    {
        public ProductCountSpecifications(ProductParameterSpecifications parameters): base(product =>
         (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
         (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value))
        {
      
        }

    }
}
