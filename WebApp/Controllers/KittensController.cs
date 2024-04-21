using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers;

public class KittensController(DataContext context) : Controller
{
    // GET: Kittens
    public async Task<IActionResult> Index()
    {
        List<Kitten> kittens = await context.Kittens.ToListAsync();
        StringValues acceptHeader = Request.Headers.Accept;
        return acceptHeader == "application/json" ? Json(kittens) : View(kittens);
    }

    // GET: Kittens/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null) return NotFound();
        

        Kitten? kitten = await context.Kittens
            .FirstOrDefaultAsync(m => m.Id == id);
        if (kitten == null)
        {
            return NotFound();
        }
        StringValues acceptHeader = Request.Headers.Accept;
        return acceptHeader == "application/json" ? Json(kitten) : View(kitten);
    }

    // GET: Kittens/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Kittens/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Cuteness,Softness")] Kitten kitten)
    {
        if (!ModelState.IsValid) return View(kitten);
        kitten.Id = Guid.NewGuid();
        context.Add(kitten);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Kittens/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null) return NotFound();
        Kitten? kitten = await context.Kittens.FindAsync(id);
        if (kitten == null) return NotFound();
        return View(kitten);
    }

    // POST: Kittens/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Cuteness,Softness")] Kitten kitten)
    {
        if (id != kitten.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid) return View(kitten);
        
        try
        {
            context.Update(kitten);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KittenExists(kitten.Id))
            {
                return NotFound();
            }
            throw;
        }

        return RedirectToAction(nameof(Index));

    }

    // GET: Kittens/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Kitten? kitten = await context.Kittens
            .FirstOrDefaultAsync(m => m.Id == id);
        return kitten == null ? NotFound() : View(kitten);
    }

    // POST: Kittens/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await context.Kittens.Where( x => x.Id == id).ExecuteDeleteAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool KittenExists(Guid id)
    {
        return context.Kittens.Any(e => e.Id == id);
    }
}