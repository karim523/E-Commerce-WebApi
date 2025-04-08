namespace Shared
{
    public class ProductParameterSpecifications
    {
        private const int MaxPageSize = 10;
        private const int DefaultPageSize = 15;
        private int _pageSize = DefaultPageSize ;
        public int PageIndex { get; set; } = 1;
        public int PageSize 
        {
            get => _pageSize;
            set=> _pageSize= value> MaxPageSize ? MaxPageSize : value;
        }
        public int? TypeId{ get; set; }
        public int? BrandId{ get; set; }
        public ProductSortOptions? Sort{ get; set; }
       
    }
    public enum ProductSortOptions
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    } 
}
