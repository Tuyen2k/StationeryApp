﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
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
            services.AddScoped<IInventoryItemServices, InventoryItemServices>();
            services.AddScoped<IMediaServices, MediaServices>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IReportServices, ReportServices>();

            services.AddScoped<ProtectedLocalStorage>();

            // services title web
            services.AddScoped<AppStateService>();

            // services for authentication
            //services.AddScoped<AuthTokenHandler>();

            //services.AddHttpClient("AuthorizedClient", client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:7069/");
            //}).AddHttpMessageHandler<AuthTokenHandler>();

            return services;
        }
    }
}
