namespace Ecommerce.Application.DTOs.Response;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProductResponse> Products { get; set; }
}
