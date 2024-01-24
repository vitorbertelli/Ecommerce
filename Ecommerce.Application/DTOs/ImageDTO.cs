﻿using Ecommerce.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs;

public class ImageDTO
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Invalid url. Url is required.")]
    [MaxLength(250, ErrorMessage = "Url length cannot exceed 250 characters.")]
    [DisplayName("Image Url")]
    public string Url { get; set; }
    public Product Product { get; set; }
    [DisplayName("Product")]
    public int ProductId { get; set; }
}
