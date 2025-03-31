using Microsoft.EntityFrameworkCore;
using NC2025_MinimalAPI_NET9.Data;
using NC2025_MinimalAPI_NET9.Endpoints;
using NC2025_MinimalAPI_NET9.Repositories.Implementations;
using NC2025_MinimalAPI_NET9.Repositories.Interfaces;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Aggiunta supporto a OpenAPI (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

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
    var oaName = "NC2025_MinimalAPI_NET9";
    var oaEndpoint = "/openapi/v1.json";
    app.MapOpenApi(oaEndpoint);

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
// app.MapGet("/", () => "Hello World!");

// Endpoint Minimal API
app.MapCategoriesEndpoints();
app.MapProductsEndpoints();

app.Run();
