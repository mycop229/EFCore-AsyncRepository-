using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string? Number { get; set; }
        [Required]
        public int LoadCapacity { get; set; }

    }
}
