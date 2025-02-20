using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add CORS support
builder.Services.AddCors();

var app = builder.Build();

// Configure CORS
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Define product endpoint with category information
app.MapGet("/api/productlist", () =>
{
    var products = new[]
    {
        new {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50,
            Stock = 25,
            Category = new { Id = 101, Name = "Electronics", Description = "Electronic devices and gadgets" }
        },
        new {
            Id = 2,
            Name = "Headphones",
            Price = 50.00,
            Stock = 100,
            Category = new { Id = 102, Name = "Accessories", Description = "Computer and phone accessories" }
        },
        new {
            Id = 3,
            Name = "Wireless Mouse",
            Price = 29.99,
            Stock = 150,
            Category = new { Id = 102, Name = "Accessories", Description = "Computer and phone accessories" }
        },
        new {
            Id = 4,
            Name = "Smart TV",
            Price = 799.99,
            Stock = 15,
            Category = new { Id = 101, Name = "Electronics", Description = "Electronic devices and gadgets" }
        }
    };

    return Results.Ok(products);
});

app.Run();
