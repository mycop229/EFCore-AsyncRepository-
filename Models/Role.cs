using System.ComponentModel.DataAnnotations;

namespace Intership.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }
    }
}
