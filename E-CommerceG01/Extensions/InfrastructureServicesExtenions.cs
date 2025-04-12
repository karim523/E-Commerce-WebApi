
using StackExchange.Redis;

namespace E_CommerceG01.Extensions
{
    public static class InfrastructureServicesExtenions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IDbIntializer, DbIntializer>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IConnectionMultiplexer>(services=> ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));

            return services;
        }
    }
}
