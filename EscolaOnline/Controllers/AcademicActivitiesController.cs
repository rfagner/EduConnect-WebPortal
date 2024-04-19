using Microsoft.AspNetCore.Mvc;
using EscolaOnline.Data;
using EscolaOnline.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EscolaOnline.Controllers
{
    public class AcademicActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;        

        public AcademicActivitiesController(ApplicationDbContext context)
        {
            _context = context;           
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.AcademicActivities.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var activity = await _context.AcademicActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null) return NotFound();

            return View(activity);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,PublishDate,AuthorId")] AcademicActivity academicActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicActivity);
        }     


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var activity = await _context.AcademicActivities.FindAsync(id);
            if (activity == null) return NotFound();

            return View(activity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,PublishDate,AuthorId")] AcademicActivity academicActivity)
        {
            if (id != academicActivity.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicActivity);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicActivityExists(academicActivity.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(academicActivity);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var activity = await _context.AcademicActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null) return NotFound();

            return View(activity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.AcademicActivities.FindAsync(id);
            _context.AcademicActivities.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }   


        private bool AcademicActivityExists(int id)
        {
            return _context.AcademicActivities.Any(e => e.Id == id);
        }
    }
}
