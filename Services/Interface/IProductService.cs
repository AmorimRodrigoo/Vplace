using ProductApi.DTOs;
using ProductApi.Models;

namespace ProductApi.Services.Interface;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<ProductDTO> GetProductById(int id);
    Task AddProduct(ProductDTO product);
    Task UpdateProduct(ProductDTO product);
    Task DeleteProduct(int id);
}