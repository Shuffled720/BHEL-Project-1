using BHEL_Project_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BHEL_Project_1.Models;

public class ComponentMasterController : Controller
{
    private readonly ApplicationDBContext _context;

    public ComponentMasterController(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.ComponentMaster.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ComponentMaster componentMaster)
    {
        if (ModelState.IsValid)
        {
            _context.Add(componentMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var componentMaster = await _context.ComponentMaster.FindAsync(id);
        if (componentMaster == null)
        {
            return NotFound();
        }
        return View(componentMaster);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ComponentMaster componentMaster)
    {
        if (id != componentMaster.ComponentMasterId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(componentMaster);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentMasterExists(componentMaster.ComponentMasterId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Home");
            
        }
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var componentMaster = await _context.ComponentMaster
            .FirstOrDefaultAsync(m => m.ComponentMasterId == id);
        if (componentMaster == null)
        {
            return NotFound();
        }

        return View(componentMaster);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var componentMaster = await _context.ComponentMaster.FindAsync(id);
        _context.ComponentMaster.Remove(componentMaster);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }

    private bool ComponentMasterExists(int id)
    {
        return _context.ComponentMaster.Any(e => e.ComponentMasterId == id);
    }
}
