using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task Create(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.Create(product);
    }

    public async Task Delete(int id)
    {
        var product = await _productRepository.GetById(id);
        await _productRepository.Delete(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var products = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetById(int id)
    {
        var product = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task Update(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.Update(product);
    }
}
