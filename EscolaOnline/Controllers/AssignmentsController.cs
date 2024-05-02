using EscolaOnline.Data;
using EscolaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaOnline.Controllers;
public class AssignmentsController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ApplicationDbContext _context;
    private readonly ILogger _logger;
    private readonly string _uploadsFolder = @"D:\dev-repos\dados\upload";

    public AssignmentsController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context, ILogger<AssignmentsController> logger)
    {
        _hostingEnvironment = hostingEnvironment;
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var assignments = _context.Assignments.ToList();
        return View(assignments);
    }

    public IActionResult Create()
    {
        return View();
    }
        

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Assignment assignment, IFormFile fileUpload)
    {
        if (ModelState.IsValid)
        {
            if (fileUpload != null)
            {
                var filePath = Path.Combine(_uploadsFolder, fileUpload.FileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }
                assignment.FilePath = filePath;
            }
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(assignment);
    }

    public IActionResult Details(int id)
    {
        var assignment = _context.Assignments.Find(id);
        if (assignment == null)
        {
            return NotFound();
        }
        return View(assignment);
    }

    public IActionResult Edit(int id)
    {
        _logger.LogInformation("Fetching assignment with ID {ID} for edit", id);
        var assignment = _context.Assignments.Find(id);
        if (assignment == null)
        {
            _logger.LogWarning("Assignment with ID {ID} not found", id);
            return NotFound();
        }
        return View(assignment);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Assignment assignment, IFormFile fileUpload)
    {
        if (id != assignment.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(assignment);
        }

        var entity = await _context.Assignments.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        if (fileUpload != null)
        {
            var filePath = Path.Combine(_uploadsFolder, fileUpload.FileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); 
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileUpload.CopyToAsync(stream);
            }
            entity.FilePath = filePath; 
        }

        _context.Entry(entity).CurrentValues.SetValues(assignment);
        try
        {
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating assignment with ID {ID}", id);
            ModelState.AddModelError("", "Error updating assignment. Please contact support.");
            return View(assignment);
        }
    }



    public IActionResult Delete(int id)
    {
        var assignment = _context.Assignments.Find(id);
        if (assignment == null)
        {
            return NotFound();
        }
        return View(assignment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var assignment = _context.Assignments.Find(id);
        if (assignment == null)
        {
            return NotFound();
        }
        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
