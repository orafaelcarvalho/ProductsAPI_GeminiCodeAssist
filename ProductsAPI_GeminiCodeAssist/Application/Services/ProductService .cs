using ProductsAPI_GeminiCodeAssist.Domain.Entities;
using ProductsAPI_GeminiCodeAssist.Domain.Interfaces;
using ProductsAPI_GeminiCodeAssist.Application.Interfaces;

namespace ProductsAPI_GeminiCodeAssist.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task CreateProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product != null)
        {
            product.SetStatusToDeleted();
            await _productRepository.UpdateAsync(product);
        }
    }
}
