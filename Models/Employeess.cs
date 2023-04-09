using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models
{
    public class Employeess
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
        [StringLength(11, MinimumLength = 11)]
        public string? NumberPhobne { get; set; }

        [Required]
        public int RegistrationDataId { get; set; }
        [ForeignKey("RegistrationDataId")]
        public virtual RegistrationData? RegistrationData { get; set; }

        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role? Role  { get; set; }
    }
}
