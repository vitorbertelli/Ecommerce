using AutoMapper;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<CategoryResponse> Create(CategoryRequest request)
    {
        var category = _mapper.Map<Category>(request);
        await _categoryRepository.Create(category);
        return _mapper.Map<CategoryResponse>(category);
    }

    public async Task Delete(int id)
    {
        var category = await _categoryRepository.GetById(id);
        await _categoryRepository.Delete(category);
    }

    public async Task<IEnumerable<CategoryResponse>> GetAll()
    {
        var categories = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryResponse>>(categories);
    }

    public async Task<CategoryResponse> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryResponse>(category);
    }

    public async Task<CategoryResponse> Update(CategoryRequest request)
    {
        var category = _mapper.Map<Category>(request);
        await _categoryRepository.Update(category);
        return _mapper.Map<CategoryResponse>(category);
    }
}
