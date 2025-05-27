using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyXe.Models;

namespace QuanLyXe.Controllers
{
    public class GasCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GasCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = _context.GasCars.Include(g => g.Branch);
            return View(await list.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.GasCars.FindAsync(id);
            if (car == null) return NotFound();

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GasCar car)
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

            var car = await _context.GasCars.FindAsync(id);
            if (car == null) return NotFound();

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.GasCars.FindAsync(id);
            _context.GasCars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
