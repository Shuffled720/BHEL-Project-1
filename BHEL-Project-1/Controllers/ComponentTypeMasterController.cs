using BHEL_Project_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using BHEL_Project_1.Models;

public class ComponentTypeMasterController : Controller
{
    private readonly ApplicationDBContext _context;

    public ComponentTypeMasterController(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var componentTypeMasters = _context.ComponentTypeMaster.Include(c => c.ComponentMaster);
        return View(await componentTypeMasters.ToListAsync());
    }

    public IActionResult Create()
    {
        ViewData["ComponentMasterId"] = new SelectList(_context.ComponentMaster, "ComponentMasterId", "Component_Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ComponentTypeMaster componentTypeMaster)
    {
        if (ModelState.IsValid)
        {
            _context.Add(componentTypeMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        ViewData["ComponentMasterId"] = new SelectList(_context.ComponentMaster, "ComponentMasterId", "Component_Name", componentTypeMaster.ComponentMasterId);
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var componentTypeMaster = await _context.ComponentTypeMaster.FindAsync(id);
        if (componentTypeMaster == null)
        {
            return NotFound();
        }
        ViewData["ComponentMasterId"] = new SelectList(_context.ComponentMaster, "ComponentMasterId", "Component_Name", componentTypeMaster.ComponentMasterId);
        return View(componentTypeMaster);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ComponentTypeMaster componentTypeMaster)
    {
        if (id != componentTypeMaster.ComponentTypeMasterId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(componentTypeMaster);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentTypeMasterExists(componentTypeMaster.ComponentTypeMasterId))
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
        ViewData["ComponentMasterId"] = new SelectList(_context.ComponentMaster, "ComponentMasterId", "Component_Name", componentTypeMaster.ComponentMasterId);
        return View(componentTypeMaster);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var componentTypeMaster = await _context.ComponentTypeMaster
            .Include(c => c.ComponentMaster)
            .FirstOrDefaultAsync(m => m.ComponentTypeMasterId == id);
        if (componentTypeMaster == null)
        {
            return NotFound();
        }

        return View(componentTypeMaster);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var componentTypeMaster = await _context.ComponentTypeMaster.FindAsync(id);
        if(componentTypeMaster == null)
		{
			return NotFound();
		}
        _context.ComponentTypeMaster.Remove(componentTypeMaster);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }

    private bool ComponentTypeMasterExists(int id)
    {
        return _context.ComponentTypeMaster.Any(e => e.ComponentTypeMasterId == id);
    }
}
