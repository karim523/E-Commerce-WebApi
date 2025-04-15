using Domain.Entities;
using Microsoft.AspNetCore.Identity;

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

            services.AddDbContext<IdentityAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<IdentityAppDbContext>();

            services.AddScoped<IDbIntializer, DbIntializer>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBasketService, BasketService>();

            services.AddSingleton<IConnectionMultiplexer>(services=> ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));

            return services;
        }
    }
}
