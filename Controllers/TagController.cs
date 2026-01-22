using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalNoticias.Models;

public class TagController : Controller {
    private readonly AppDbContext _context;

    public TagController(AppDbContext context) {
        _context = context;
    }

    public async Task<IActionResult> Index() {
        var tags = await _context.Tags.ToListAsync();
        return View(tags);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Tag tag) {
        if (!ModelState.IsValid)
            return View(tag);

        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
            return NotFound();

        return View(tag);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Tag tag) {
        if (!ModelState.IsValid)
            return View(tag);

        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
            return NotFound();

        return View(tag);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
            return NotFound();

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

}
