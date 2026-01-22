using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalNoticias.Models;
using PortalNoticias.ViewModels;

public class NoticiaController : Controller {
    private readonly AppDbContext _context;

    public NoticiaController(AppDbContext context) {
        _context = context;
    }

    public async Task<IActionResult> Index() {
        var noticias = await _context.Noticias
            .Include(n => n.NoticiaTags)
            .ThenInclude(nt => nt.Tag)
            .ToListAsync();

        return View(noticias);
    }

    [HttpGet]
    public async Task<IActionResult> Create() {
        ViewBag.Tags = await _context.Tags.ToListAsync();

        return PartialView(new NoticiaViewModel {
            TagIds = new List<int>()
        });
    }


    [HttpPost]
    public async Task<IActionResult> Create(NoticiaViewModel model) {
        var noticia = new Noticia {
            Titulo = model.Titulo,
            Texto = model.Texto,
            UsuarioId = 1 // mock para a prova
        };

        foreach (var tagId in model.TagIds) {
            noticia.NoticiaTags.Add(new NoticiaTag {
                TagId = tagId
            });
        }

        _context.Noticias.Add(noticia);
        await _context.SaveChangesAsync();

        return Json(new { sucesso = true });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id) {
        var noticia = await _context.Noticias
            .FirstOrDefaultAsync(n => n.Id == id);

        if (noticia == null)
            return NotFound();

        return View(noticia);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var noticia = await _context.Noticias
            .Include(n => n.NoticiaTags)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (noticia == null)
            return NotFound();

        _context.NoticiaTags.RemoveRange(noticia.NoticiaTags);
        _context.Noticias.Remove(noticia);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id) {
        var noticia = await _context.Noticias
            .Include(n => n.NoticiaTags)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (noticia == null)
            return NotFound();

        var model = new NoticiaViewModel {
            Id = noticia.Id,
            Titulo = noticia.Titulo,
            Texto = noticia.Texto,
            TagIds = noticia.NoticiaTags.Select(nt => nt.TagId).ToList()
        };

        ViewBag.Tags = await _context.Tags.ToListAsync();

        return PartialView("_Form", model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(NoticiaViewModel model) {
        var noticia = await _context.Noticias
            .Include(n => n.NoticiaTags)
            .FirstOrDefaultAsync(n => n.Id == model.Id);

        if (noticia == null)
            return NotFound();

        noticia.Titulo = model.Titulo;
        noticia.Texto = model.Texto;

        _context.NoticiaTags.RemoveRange(noticia.NoticiaTags);

        foreach (var tagId in model.TagIds) {
            noticia.NoticiaTags.Add(new NoticiaTag {
                TagId = tagId
            });
        }

        await _context.SaveChangesAsync();

        return Json(new { sucesso = true });
    }

}
