using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyXe.Models
{
    public class ElectricCar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Battery { get; set; } // kWh

        [Required]
        public int RangeKm { get; set; } // km

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
