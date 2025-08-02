using System.ComponentModel.DataAnnotations;

namespace CarManufacturersAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Model { get; set; } = string.Empty;
        
        public int Year { get; set; }
        
        [StringLength(50)]
        public string? Color { get; set; }
        
        public decimal Price { get; set; }
        
        public int ManufacturerId { get; set; }
        
        public Manufacturer? Manufacturer { get; set; }
    }
} 