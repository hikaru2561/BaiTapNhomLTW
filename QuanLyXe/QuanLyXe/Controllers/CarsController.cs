using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyXe.Models;

namespace QuanLyXe.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gas = await _context.GasCars.Include(c => c.Branch).ToListAsync();
            var electric = await _context.ElectricCars.Include(c => c.Branch).ToListAsync();

            ViewBag.GasCars = gas;
            ViewBag.ElectricCars = electric;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // Gợi ý mở rộng thêm: lựa chọn tạo Gas hoặc Electric trong ViewModel
    }
}
