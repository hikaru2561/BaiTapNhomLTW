using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyXe.Models
{
    public class GasCar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float FuelEff { get; set; } // L/100km

        [Required, StringLength(100)]
        public string Model { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public string ImageUrl { get; set; }
    }
}
