using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IImageRepository
{
    Task<IEnumerable<Image>> GetAll();
    Task<Image> GetById(int id);
    Task<Image> Create(Image image);
    Task<Image> Update(Image image);
    Task<Image> Delete(Image image);
}
