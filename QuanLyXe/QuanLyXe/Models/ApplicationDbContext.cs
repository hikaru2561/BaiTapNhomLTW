using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QuanLyXe.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<ElectricCar> ElectricCars { get; set; }
        public DbSet<GasCar> GasCars { get; set; }
    }
}
