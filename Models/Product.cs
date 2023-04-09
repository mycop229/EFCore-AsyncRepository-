using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public double Weight { get; set; }

    }
}
