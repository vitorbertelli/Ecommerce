using Ecommerce.Application.DTOs;
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
    public async Task<ActionResult<IEnumerable<ImageDTO>>> GetAll()
    {
        var images = await _imageService.GetAll();
        if (images == null) return NotFound("Images not found");
        return Ok(images);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ImageDTO>> GetById(int id)
    {
        var image = await _imageService.GetById(id);
        if (image == null) return NotFound("Image not found");
        return Ok(image);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ImageDTO imageDto)
    {
        if (imageDto == null) return BadRequest("Invalid Data");
        await _imageService.Create(imageDto);
        return new CreatedAtRouteResult("GetById", new { id = imageDto.Id }, imageDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ImageDTO imageDto)
    {
        if (imageDto == null) return BadRequest("Invalid Data");
        if (id != imageDto.Id) return BadRequest("Invalid Id");
        await _imageService.Update(imageDto);
        return Ok(imageDto);
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
