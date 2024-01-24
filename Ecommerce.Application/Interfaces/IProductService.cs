using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAll();
    Task<ProductDTO> GetById(int id);
    Task Create(ProductDTO productDto);
    Task Update(ProductDTO productDto);
    Task Delete(int id);
}
