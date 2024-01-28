using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs.Request;

public class ImageRequest
{
    [Required(ErrorMessage = "Invalid url. Url is required.")]
    [MaxLength(250, ErrorMessage = "Url length cannot exceed 250 characters.")]
    [DisplayName("Image Url")]
    public string Url { get; set; }
    [Required(ErrorMessage = "Invalid productId. Product is required.")]
    [DisplayName("Product")]
    public int ProductId { get; set; }
}
