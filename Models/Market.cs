using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models
{
    [Table("Markets")]
    public class Market
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Name { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string? Address { get; set; }
    }
}
