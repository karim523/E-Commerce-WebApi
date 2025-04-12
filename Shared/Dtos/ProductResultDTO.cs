namespace Shared.Dtos
{
    public record ProductResultDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string TypeName { get; set; }
        public string BrandName { get; set; }
    }
}
