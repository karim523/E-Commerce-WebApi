using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ProductWithBrandAndTypeSpecifications(string? sort, int? brandId, int? typeId)
            : base(product =>
                 (!brandId.HasValue || product.BrandId == brandId.Value) &&
                 (!typeId.HasValue || product.TypeId == typeId.Value))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower().Trim())
                {
                    case "pricedesc":
                        SetOrderByDescending(p => p.Price);
                        break;
                    case "priceasc":
                        SetOrderBy(p => p.Price);
                        break;
                    case "namedesc":
                        SetOrderByDescending(p => p.Name);
                        break;
                    default:
                        SetOrderBy(p => p.Name);
                        break;
                }
            }
        }

    }
}
