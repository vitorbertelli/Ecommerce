using AutoMapper;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}
