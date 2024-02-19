using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAll()
    {
        var products = await _productService.GetAll();
        if (products == null) return NotFound("Products not found");
        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult<ProductResponse>> GetById(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null) return NotFound("Product not found");
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Post([FromBody] ProductRequest request)
    {
        if (request == null) return BadRequest("Invalid Data");
        var response = await _productService.Create(request);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProductResponse>> Put(int id, [FromBody] ProductRequest request)
    {
        if (request == null) return BadRequest("Invalid Data");
        if (id != request.Id) return BadRequest("Invalid data.");
        await _productService.Update(request);
        return Ok(request);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null) return NotFound("Product not found");
        await _productService.Delete(id);
        return Ok(product);
    }
}
