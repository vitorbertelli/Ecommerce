using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Interfaces;

public interface IImageService
{
    Task<IEnumerable<ImageDTO>> GetAll();
    Task<ImageDTO> GetById(int id);
    Task Create(ImageDTO imageDto);
    Task Update(ImageDTO imageDto);
    Task Delete(int id);
}
