using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;

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
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
    {
        var categories = await _categoryService.GetAll();
        if (categories == null) return NotFound("Categories not found.");
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> GetById(int id)
    {
        var category = await _categoryService.GetById(id);
        if (category == null) return NotFound("Category not found.");
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
    {
        if (categoryDto == null) return BadRequest("Invalid data.");
        await _categoryService.Create(categoryDto);
        return new CreatedAtRouteResult("GetById", new { id = categoryDto.Id }, categoryDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
    {
        if (categoryDto == null) return BadRequest("Invalid data.");
        if (id != categoryDto.Id) return BadRequest("Invalid id.");
        await _categoryService.Update(categoryDto);
        return Ok(categoryDto);
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
