using System.Text.Json;

namespace Persistance.Data.DataSeeding
{
    public class DbIntializer : IDbIntializer
    {
        private readonly AppDbContext _context;

        public DbIntializer(AppDbContext context)
        {
            _context = context;
        }

        public async Task IntializeAsync()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    await _context.Database.MigrateAsync();
                    if (!_context.ProductTypes.Any())
                    {
                        var typeData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\types.json");
                        var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                        if (types is not null && types.Any())
                        {
                            await _context.AddRangeAsync(types);
                            await _context.SaveChangesAsync();
                        }

                    }

                    if (!_context.ProductBrands.Any())
                    {
                        var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\brands.json");
                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                        if (brands is not null && brands.Any())
                        {
                            await _context.AddRangeAsync(brands);
                            await _context.SaveChangesAsync();
                        }

                    }

                    if (!_context.Products.Any())
                    {
                        var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\products.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                        if (products is not null && products.Any())
                        {
                            await _context.AddRangeAsync(products);
                            await _context.SaveChangesAsync();
                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
