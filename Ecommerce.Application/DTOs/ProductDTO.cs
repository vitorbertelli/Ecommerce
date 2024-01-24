using Ecommerce.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Application.DTOs;

public class ProductDTO
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Invalid name. Name is required.")]
    [MaxLength(50, ErrorMessage = "Name length cannot exceed 50 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Price cannot be negative or null.")]
    [Column(TypeName = "decimal(10, 2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Stock cannot be negative or null.")]
    [Range(1, 9999)]
    public int Stock { get; set; }
    public Category Category { get; set; }
    [DisplayName("Category")]
    public int CategoryId { get; set; }
}
