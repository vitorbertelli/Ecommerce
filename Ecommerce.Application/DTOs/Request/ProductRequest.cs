using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Application.DTOs.Request;

public class ProductRequest
{
    [Required(ErrorMessage = "Invalid name. Name is required.")]
    [MaxLength(50, ErrorMessage = "Name length cannot exceed 50 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Price cannot be null.")]
    [Column(TypeName = "decimal(10, 2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [Range(0, 9999.99, ErrorMessage = "Price cannot be negative.")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Stock cannot be null.")]
    [Range(0, 9999, ErrorMessage = "Stock cannot be negative.")]
    public int Stock { get; set; }
    [Required(ErrorMessage = "Invalid categoryId. Category is required.")]
    [DisplayName("Category")]
    public int CategoryId { get; set; }
}
