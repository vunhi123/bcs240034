using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MID_BCS240034.Data;
using MID_BCS240034.Models;

namespace MID_BCS240034.Controllers
{
    public class EventCategory_BCS240034Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventCategory_BCS240034Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventCategory_BCS240034
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventCategories_BCS240034.ToListAsync());
        }

        // GET: EventCategory_BCS240034/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.EventCategories_BCS240034.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }

        // GET: EventCategory_BCS240034/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventCategory_BCS240034/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] EventCategory_BCS240034 eventCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventCategory);
        }

        // GET: EventCategory_BCS240034/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.EventCategories_BCS240034.FindAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: EventCategory_BCS240034/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] EventCategory_BCS240034 eventCategory)
        {
            if (id != eventCategory.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.EventCategories_BCS240034.Any(e => e.Id == eventCategory.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventCategory);
        }

        // GET: EventCategory_BCS240034/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.EventCategories_BCS240034.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }

        // POST: EventCategory_BCS240034/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool hasEvent = _context.Events_BCS240034.Any(x => x.EventCategoryId == id);
            if (hasEvent)
            {
                TempData["Error"] = "Loại sự kiện đang được sử dụng";
                return RedirectToAction(nameof(Index));
            }

            var category = await _context.EventCategories_BCS240034.FindAsync(id);
            if (category != null)
            {
                _context.EventCategories_BCS240034.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
