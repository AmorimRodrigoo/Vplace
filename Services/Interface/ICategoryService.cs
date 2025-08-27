using ProductApi.DTOs;

namespace ProductApi.Services.Interface;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
    Task<CategoryDTO> GetCategoriesById(int id);
    Task CreateCategory(CategoryDTO category);
    Task UpdateCategory(CategoryDTO category);
    Task DeleteCategory(int id);   
}