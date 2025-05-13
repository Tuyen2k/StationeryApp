using StationeryManager.Services;
using StationeryManager.Services.Impl;

namespace StationeryManager.Util
{
    public static class ConfigurationDIService
    {
        public static IServiceCollection AddConfigurationDIService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(sp =>
            {
                return new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7069/")
                };
            });

            // service clients
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IInventoryTransactionServices, InventoryTransactionServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ISubCategoryServices, SubCategoryServices>();
            services.AddScoped<IWarehouseServices, WarehouseServices>();


            services.AddScoped<AppStateService>();

            return services;
        }
    }
}
