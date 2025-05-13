using Microsoft.EntityFrameworkCore;
using StationeryManagerApi;
using StationeryManagerApi.Extentions;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var allowCORS = "AllowCORSPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowCORS,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuration service in project
builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StationeryDBContext>();
    dbContext.Database.Migrate(); // Áp dụng các migration và tạo DB nếu chưa có
}

// Bật CORS middleware
app.UseCors(allowCORS);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
