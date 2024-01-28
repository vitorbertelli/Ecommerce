using AutoMapper;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IMapper _mapper;

    public ImageService(IImageRepository imageRepository, IMapper mapper)
    {
        _imageRepository = imageRepository;
        _mapper = mapper;
    }
    public async Task<ImageResponse> Create(ImageRequest request)
    {
        var image = _mapper.Map<Image>(request);
        await _imageRepository.Create(image);
        return _mapper.Map<ImageResponse>(image);
    }

    public async Task Delete(int id)
    {
        var image = await _imageRepository.GetById(id);
        await _imageRepository.Delete(image);
    }

    public async Task<IEnumerable<ImageResponse>> GetAll()
    {
        var images = await _imageRepository.GetAll();
        return _mapper.Map<IEnumerable<ImageResponse>>(images);
    }

    public async Task<ImageResponse> GetById(int id)
    {
        var image = await _imageRepository.GetById(id);
        return _mapper.Map<ImageResponse>(image);
    }

    public async Task<ImageResponse> Update(ImageRequest request)
    {
        var image = _mapper.Map<Image>(request);
        await _imageRepository.Update(image);
        return _mapper.Map<ImageResponse>(image);
    }
}