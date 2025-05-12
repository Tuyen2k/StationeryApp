using Microsoft.EntityFrameworkCore;
using StationeryManagerApi.Repository;
using StationeryManagerApi.Repository.Impl;
using StationeryManagerApi.Service;
using StationeryManagerApi.Service.Impl;
using StationeryManagerApi.Services;

namespace StationeryManagerApi.Extentions
{
    public static class DIExtentionModel
    {
        /// <summary>
        /// Register list service in project
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<StationeryDBContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // add repo
            services.AddScoped<IAccountRepositories, AccountRepositories>();
            services.AddScoped<ICategoryRepositories, CategoryRepositories>();
            services.AddScoped<IInventoryTransactionRepositories, InventoryTransactionRepositories>();
            services.AddScoped<IProductRepositories, ProductRepositories>();
            services.AddScoped<ISubCategoryRepositories, SubCategoryRepositories>();
            services.AddScoped<IWarehouseRepositories, WarehouseRepositories>();

            // add service
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IInventoryTransactionServices, InventoryTransactionServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ISubCategoryServices, SubCategoryServices>();
            services.AddScoped<IWarehouseServices, WarehouseServices>();
            services.AddScoped<IPasswordServices, PasswordServices>();

            return services;
        }
    }
}
