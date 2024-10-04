using Microsoft.EntityFrameworkCore;
using ProductsAPI_GeminiCodeAssist.Application.Interfaces;
using ProductsAPI_GeminiCodeAssist.Application.Services;
using ProductsAPI_GeminiCodeAssist.Domain.Interfaces;
using ProductsAPI_GeminiCodeAssist.Infra.DataContext;
using ProductsAPI_GeminiCodeAssist.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<ProductsDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection")));

// Register services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add controllers and API support
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ProductsAPI_GeminiCodeAssist", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsAPI_GeminiCodeAssist v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
