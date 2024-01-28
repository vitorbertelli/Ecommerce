namespace Ecommerce.Application.DTOs.Response;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public ICollection<ImageResponse>? Images { get; set; }
}
