using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
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
    public async Task<ProductResponse> Create(ProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        await _productRepository.Create(product);
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task Delete(int id)
    {
        var product = await _productRepository.GetById(id);
        await _productRepository.Delete(product);
    }

    public async Task<IEnumerable<ProductResponse>> GetAll()
    {
        var products = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public async Task<ProductResponse> GetById(int id)
    {
        var product = await _productRepository.GetById(id);
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<ProductResponse> Update(ProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        await _productRepository.Update(product);
        return _mapper.Map<ProductResponse>(product);
    }
}
