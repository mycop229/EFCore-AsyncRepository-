using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models
{
    [Table("RegistrationDatas")]
    public class RegistrationData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Login { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Password { get; set; }
    }
}
