using Microsoft.EntityFrameworkCore;
using NC2025_MinimalAPI_NET8.Data;
using NC2025_MinimalAPI_NET8.Endpoints;
using NC2025_MinimalAPI_NET8.Repositories.Implementations;
using NC2025_MinimalAPI_NET8.Repositories.Interfaces;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Aggiunta supporto a OpenAPI (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); 

var app = builder.Build();

// Attività da effettuare sul DB (Migrations e Seed)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Applica eventuali migrazioni in sospeso
    dbContext.Database.Migrate();

    // Effettua il seed iniziale
    DataSeeder.Seed(dbContext);
}

if (app.Environment.IsDevelopment())
{
    // Aggiunta supporto a OpenAPI (Swagger)
    var oaName = "NC2025_MinimalAPI_NET8";
    var oaEndpoint = "/openapi/v1.json";
    app.UseSwagger();

    // Swashbuckle.AspNetCore.SwaggerUI
    // default URL: /swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(oaEndpoint, oaName);
    });

    // Swashbuckle.AspNetCore.ReDoc
    // default URL: /api-docs
    app.UseReDoc(c =>
    {
        c.DocumentTitle = oaName;
        c.SpecUrl = oaEndpoint;
    });

    // Scalar.AspNetCore
    // default URL: /scalar
    app.MapScalarApiReference();
}

// Metodi Minimal API
app.MapGet("/", (HttpRequest request) =>
{
    var dic = request.Query
        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    return Results.Json(dic);
});

app.MapPost("/", (HttpRequest request) =>
{
    var dic = request.HasFormContentType
        ? request.Form.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString())
        : new Dictionary<string, string>();
    return Results.Json(dic);
});

// Endpoint Minimal API
app.MapCategoriesEndpoints();
app.MapProductsEndpoints();

app.Run();
