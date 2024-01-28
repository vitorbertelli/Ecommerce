using AutoMapper;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryRequest, Category>();
        CreateMap<Category, CategoryResponse>();
    }
}
