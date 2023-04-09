using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string? ProductListName { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public DateTime Date { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public int MarketId { get; set; }
        [ForeignKey("MarketId")]
        public virtual Market? Market { get; set; }
        [Required]
        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver? Driver { get; set; }
    }
}
