
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoCosmeticos.Models;
using CatalogoCosmeticos.Models.Data;

public class CategoriasController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: COSMETICOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Cosmeticos.ToListAsync());
    }

    // GET: COSMETICOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cosmetico = await _context.Cosmeticos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cosmetico == null)
        {
            return NotFound();
        }

        return View(cosmetico);
    }

    // GET: COSMETICOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: COSMETICOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,Stock")] Cosmetico cosmetico)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cosmetico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cosmetico);
    }

    // GET: COSMETICOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cosmetico = await _context.Cosmeticos.FindAsync(id);
        if (cosmetico == null)
        {
            return NotFound();
        }
        return View(cosmetico);
    }

    // POST: COSMETICOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Descripcion,Precio,Stock")] Cosmetico cosmetico)
    {
        if (id != cosmetico.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cosmetico);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CosmeticoExists(cosmetico.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cosmetico);
    }

    // GET: COSMETICOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cosmetico = await _context.Cosmeticos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cosmetico == null)
        {
            return NotFound();
        }

        return View(cosmetico);
    }

    // POST: COSMETICOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var cosmetico = await _context.Cosmeticos.FindAsync(id);
        if (cosmetico != null)
        {
            _context.Cosmeticos.Remove(cosmetico);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CosmeticoExists(int? id)
    {
        return _context.Cosmeticos.Any(e => e.Id == id);
    }
}
