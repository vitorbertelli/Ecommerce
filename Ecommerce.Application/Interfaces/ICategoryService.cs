using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;

namespace Ecommerce.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponse>> GetAll();
    Task<CategoryResponse> GetById(int id);
    Task<CategoryResponse> Create(CategoryRequest request);
    Task<CategoryResponse> Update(CategoryRequest request);
    Task Delete(int id);
}
