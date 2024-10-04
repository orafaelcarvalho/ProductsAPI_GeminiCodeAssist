using ProductsAPI_GeminiCodeAssist.Domain.Entities;

namespace ProductsAPI_GeminiCodeAssist.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
}
