using ProductsAPI_GeminiCodeAssist.Domain.Entities;

namespace ProductsAPI_GeminiCodeAssist.Application.Interfaces;

public interface IProductService
{
    Task<Product> GetProductByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(Guid id);
}
