using Ecommerce.Application.DTOs.Request;
using Ecommerce.Application.DTOs.Response;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAll()
    {
        var categories = await _categoryService.GetAll();
        if (categories == null) return NotFound("Categories not found.");
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryResponse>> GetById(int id)
    {
        var category = await _categoryService.GetById(id);
        if (category == null) return NotFound("Category not found.");
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> Post([FromBody] CategoryRequest request)
    {
        if (request == null) return BadRequest("Invalid data.");
        var response = await _categoryService.Create(request);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CategoryResponse>> Put(int id, [FromBody] CategoryRequest request)
    {
        if (request == null) return BadRequest("Invalid data.");
        var response = await _categoryService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var category = await _categoryService.GetById(id);
        if (category == null) return NotFound("Category not found");
        await _categoryService.Delete(id);
        return Ok();
    }
}
