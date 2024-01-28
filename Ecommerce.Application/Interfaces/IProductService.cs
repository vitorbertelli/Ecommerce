using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAll();
    Task<ProductResponse> GetById(int id);
    Task<ProductResponse> Create(ProductRequest productRequest);
    Task<ProductResponse> Update(ProductRequest productRequest);
    Task Delete(int id);
}
