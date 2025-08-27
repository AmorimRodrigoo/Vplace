using ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3)]
    [StringLength(100)]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Stock is required")]
    [Range(1, 9999)]
    public long Stock { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [MinLength(3)]
    [StringLength(200)]
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}