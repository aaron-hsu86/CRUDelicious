#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _3_CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 chars")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Chef is required")]
    [MinLength(2, ErrorMessage = "Chef name must be at least 2 chars")]
    public string Chef { get; set; }
    [Required(ErrorMessage = "Please select a Tastiness value")]
    public int Tastiness { get; set; }
    [Required(ErrorMessage = "Please provide # of Calories")]
    [Range(0, Int32.MaxValue, ErrorMessage = "Please provide valid Calories. Calories cannot be negative")]
    public int Calories { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}