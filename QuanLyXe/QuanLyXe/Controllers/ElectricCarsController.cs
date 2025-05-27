using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyXe.Models;

namespace QuanLyXe.Controllers
{
    public class ElectricCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElectricCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = _context.ElectricCars.Include(e => e.Branch);
            return View(await list.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.ElectricCars.FindAsync(id);
            if (car == null) return NotFound();

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ElectricCar car)
        {
            if (id != car.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.ElectricCars.FindAsync(id);
            if (car == null) return NotFound();

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.ElectricCars.FindAsync(id);
            _context.ElectricCars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
