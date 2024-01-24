using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Context;

namespace Ecommerce.Infrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationDbContext _imageContext;

    public ImageRepository(ApplicationDbContext context)
    {
        _imageContext = context;
    }
    public async Task<Image> Create(Image image)
    {
        _imageContext.Add(image);
        await _imageContext.SaveChangesAsync();
        return image;
    }

    public async Task<Image> Delete(Image image)
    {
        _imageContext.Remove(image);
        await _imageContext.SaveChangesAsync();
        return image;
    }

    public async Task<IEnumerable<Image>> GetAll()
    {
        return await _imageContext.Images.ToListAsync();
    }

    public async Task<Image> GetById(int id)
    {
        return await _imageContext.Images.FindAsync(id);
    }

    public async Task<Image> Update(Image image)
    {
        _imageContext.Update(image);
        await _imageContext.SaveChangesAsync();
        return image;
    }
}
