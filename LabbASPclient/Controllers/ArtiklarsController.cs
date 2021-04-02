using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabbASPclient.Models;

namespace LabbASPclient.Controllers
{
    public class ArtiklarsController : Controller
    {
        private readonly LagerContext _context;

        public ArtiklarsController(LagerContext context)
        {
            _context = context;
        }

        // GET: Artiklars
        public async Task<IActionResult> Index()
        {
            try
            {
                var lagerContext = _context.Artiklars.Include(a => a.Kategorinamn);
                return View(await lagerContext.ToListAsync());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering");
            }
        }
        // GET: Artiklars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiklar = await _context.Artiklars
                .Include(a => a.Kategorinamn)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artiklar == null)
            {
                return NotFound();
            }

            return View(artiklar);
        }

        // GET: Artiklars/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["KategoriId"] = new SelectList(_context.Kategoris, "KategoriId", "Kategorinamn");
                return View();
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering");
            }
           
        }

        // POST: Artiklars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Produktnamn,Produktbeskrivning,Tillverkare,Pris,Antal,KategoriId")] Artiklar artiklar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(artiklar);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["KategoriId"] = new SelectList(_context.Kategoris, "KategoriId", "Kategorinamn", artiklar.KategoriId);
                return View(artiklar);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering");
            }
        }

        // GET: Artiklars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var artiklar = await _context.Artiklars.FindAsync(id);
                if (artiklar == null)
                {
                    return NotFound();
                }
                ViewData["KategoriId"] = new SelectList(_context.Kategoris, "KategoriId", "Kategorinamn", artiklar.KategoriId);
                return View(artiklar);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering");
            }
        }

        // POST: Artiklars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Produktnamn,Produktbeskrivning,Tillverkare,Pris,Antal,KategoriId")] Artiklar artiklar)
        {
            try
            {
                if (id != artiklar.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(artiklar);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArtiklarExists(artiklar.Id))
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
                ViewData["KategoriId"] = new SelectList(_context.Kategoris, "KategoriId", "KategoriId", artiklar.KategoriId);
                return View(artiklar);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering");
            }
        }

        // GET: Artiklars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var artiklar = await _context.Artiklars
                    .Include(a => a.Kategorinamn)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (artiklar == null)
                {
                    return NotFound();
                }

                return View(artiklar);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering");
            }
        }

        // POST: Artiklars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var artiklar = await _context.Artiklars.FindAsync(id);
                _context.Artiklars.Remove(artiklar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering");
            }
           
        }
        private bool ArtiklarExists(int id)
        {
                return _context.Artiklars.Any(e => e.Id == id);
        }
        public ActionResult Felhantering()
        {
            return View();
        }
    }
}
