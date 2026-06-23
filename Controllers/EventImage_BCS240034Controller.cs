using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MID_BCS240034.Data;
using MID_BCS240034.Models;

namespace MID_BCS240034.Controllers
{
    public class EventImage_BCS240034Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventImage_BCS240034Controller(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: EventImage_BCS240034
        public async Task<IActionResult> Index()
        {
            var images = await _context.EventImages_BCS240034
                .Include(i => i.Event)
                .ToListAsync();
            return View(images);
        }

        // GET: EventImage_BCS240034/Create?eventId=1
        public IActionResult Create(int? eventId)
        {
            if (eventId == null) return BadRequest();
            ViewData["EventId"] = eventId.Value;
            return View();
        }

        // POST: EventImage_BCS240034/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl,IsThumbnail,EventId")] EventImage_BCS240034 image, IFormFile? ImageFile)
        {
            // If a file was uploaded, save it to wwwroot/images and set ImageUrl
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var wwwRoot = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var uploads = Path.Combine(wwwRoot, "images");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                image.ImageUrl = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                if (image.IsThumbnail)
                {
                    var oldThumb = _context.EventImages_BCS240034.Where(x => x.EventId == image.EventId && x.IsThumbnail);
                    foreach (var item in oldThumb)
                    {
                        item.IsThumbnail = false;
                    }
                }

                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Event_BCS240034", new { id = image.EventId });
            }
            ViewData["EventId"] = image.EventId;
            return View(image);
        }

        // GET: EventImage_BCS240034/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var image = await _context.EventImages_BCS240034
                .Include(i => i.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null) return NotFound();

            return View(image);
        }

        // POST: EventImage_BCS240034/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.EventImages_BCS240034.FindAsync(id);
            if (image != null)
            {
                var eventId = image.EventId;
                _context.EventImages_BCS240034.Remove(image);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Event_BCS240034", new { id = eventId });
            }
            return RedirectToAction("Index", "Event_BCS240034");
        }
    }
}
