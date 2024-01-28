using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;

namespace Ecommerce.Application.Interfaces;

public interface IImageService
{
    Task<IEnumerable<ImageResponse>> GetAll();
    Task<ImageResponse> GetById(int id);
    Task<ImageResponse> Create(ImageRequest request);
    Task<ImageResponse> Update(ImageRequest request);
    Task Delete(int id);
}
