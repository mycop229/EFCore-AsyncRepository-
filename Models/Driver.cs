using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models
{
    [Table("Drivers")]
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Surname { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? MiddleName { get; set; }
        [Required]
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Car? Car { get; set; }
    }
}
