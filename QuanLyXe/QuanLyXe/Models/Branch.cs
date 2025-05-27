using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyXe.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Country { get; set; }

        // Navigation properties (1 Branch -> nhiều xe)
        public ICollection<ElectricCar> ElectricCars { get; set; }
        public ICollection<GasCar> GasCars { get; set; }
    }
}
