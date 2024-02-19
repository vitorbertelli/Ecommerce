using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ImageResponse>>> GetAll()
    {
        var images = await _imageService.GetAll();
        if (images == null) return NotFound("Images not found");
        return Ok(images);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ImageResponse>> GetById(int id)
    {
        var image = await _imageService.GetById(id);
        if (image == null) return NotFound("Image not found");
        return Ok(image);
    }

    [HttpPost]
    public async Task<ActionResult<ImageResponse>> Post([FromBody] ImageRequest request)
    {
        if (request == null) return BadRequest("Invalid Data");
        var response = await _imageService.Create(request);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ImageResponse>> Put(int id, [FromBody] ImageRequest request)
    {
        if (request == null) return BadRequest("Invalid Data");
        if (id != request.Id) return BadRequest("Invalid data.");
        var response = await _imageService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var image = await _imageService.GetById(id);
        if (image == null) return NotFound("Image not found");
        await _imageService.Delete(id);
        return Ok(image);
    }
}
