using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Context;

namespace Ecommerce.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _categoryContext;

    public CategoryRepository(ApplicationDbContext context)
    {
        _categoryContext = context;        
    }
    public async Task<Category> Create(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _categoryContext.Categories.Include(c => c.Products).ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await _categoryContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> Update(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
