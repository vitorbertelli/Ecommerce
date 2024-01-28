using AutoMapper;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Profiles;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<ImageRequest, Image>();
        CreateMap<Image, ImageResponse>();
    }
}
