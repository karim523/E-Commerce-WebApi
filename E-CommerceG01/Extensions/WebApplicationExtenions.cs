namespace E_CommerceG01.Extensions
{
    public static class WebApplicationExtenions
    {
        public static async Task<WebApplication> SeedBbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbIntializer>();
            await dbIntializer.IntializeAsync();
            return app;
        }
        public static WebApplication UseCustomMiddleware(this WebApplication app)
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return app;
        }
    }
}
