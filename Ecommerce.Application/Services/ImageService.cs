using AutoMapper;
using Ecommerce.Application.DTOs;
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
    public async Task Create(ImageDTO imageDto)
    {
        var image = _mapper.Map<Image>(imageDto);
        await _imageRepository.Create(image);
    }

    public async Task Delete(int id)
    {
        var image = await _imageRepository.GetById(id);
        await _imageRepository.Delete(image);
    }

    public async Task<IEnumerable<ImageDTO>> GetAll()
    {
        var images = await _imageRepository.GetAll();
        return _mapper.Map<IEnumerable<ImageDTO>>(images);
    }

    public async Task<ImageDTO> GetById(int id)
    {
        var image = await _imageRepository.GetById(id);
        return _mapper.Map<ImageDTO>(image);
    }

    public async Task Update(ImageDTO imageDto)
    {
        var image = _mapper.Map<Image>(imageDto);
        await _imageRepository.Update(image);
    }
}