using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs.Request;

public class CategoryRequest
{
    [Required(ErrorMessage = "Invalid name. Name is required.")]
    [MaxLength(50, ErrorMessage = "Name length cannot exceed 50 characters.")]
    public string Name { get; set; }
}
