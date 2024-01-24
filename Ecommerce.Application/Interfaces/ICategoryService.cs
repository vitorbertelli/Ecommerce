using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAll();
    Task<CategoryDTO> GetById(int id);
    Task Create(CategoryDTO categoryDto);
    Task Update(CategoryDTO categoryDto);
    Task Delete(int id);
}
