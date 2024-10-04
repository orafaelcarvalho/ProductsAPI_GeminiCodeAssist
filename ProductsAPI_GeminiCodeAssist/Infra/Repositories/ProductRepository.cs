using Microsoft.EntityFrameworkCore;
using ProductsAPI_GeminiCodeAssist.Domain.Entities;
using ProductsAPI_GeminiCodeAssist.Domain.Interfaces;
using ProductsAPI_GeminiCodeAssist.Infra.DataContext;

namespace ProductsAPI_GeminiCodeAssist.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductsDataContext _context;

    public ProductRepository(ProductsDataContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}
