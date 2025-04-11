namespace E_CommerceG01.Extensions
{
    public static class PresentitionServicesExtenions
    {
        public static IServiceCollection AddPresentitionServices(this IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidationErrorResponse;
            });
            return services;
        }
    }
}
