using AutoMapper;
using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Services.Interface;

namespace ProductApi.Services;

public class CategoryService : ICategoryService
{
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntitiy = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntitiy);
    }

    public async Task<CategoryDTO> GetCategoriesById(int id)
    {
        var categoriesEntitiy = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoriesEntitiy);
    }
    
    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntitiy = await _categoryRepository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntitiy);
    }

    public async Task CreateCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(categoryEntity);
        categoryDto.CategoryID = categoryEntity.CategoryId;;
    }

    public async Task UpdateCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Update(categoryEntity);
    }

    public async Task DeleteCategory(int id)
    {
        var categoryEntity = _categoryRepository.GetById(id);
        await _categoryRepository.Delete(categoryEntity.Id);
    }
}