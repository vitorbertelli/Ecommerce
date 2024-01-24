using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs;

public class CategoryDTO
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Invalid name. Name is required.")]
    [MaxLength(50, ErrorMessage = "Name length cannot exceed 50 characters.")]
    public string Name { get; set; }
}
