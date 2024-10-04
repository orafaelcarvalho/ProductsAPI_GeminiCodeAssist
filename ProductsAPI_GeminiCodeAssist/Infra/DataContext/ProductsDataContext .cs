using Microsoft.EntityFrameworkCore;
using ProductsAPI_GeminiCodeAssist.Domain.Entities;

namespace ProductsAPI_GeminiCodeAssist.Infra.DataContext;

public class ProductsDataContext : DbContext
{
    public ProductsDataContext(DbContextOptions<ProductsDataContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Status)
                .HasConversion<string>(); 
        });
    }
}
