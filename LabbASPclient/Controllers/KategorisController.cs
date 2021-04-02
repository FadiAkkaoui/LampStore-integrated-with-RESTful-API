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
    public class KategorisController : Controller
    {
        private readonly LagerContext _context;

        public KategorisController(LagerContext context)
        {
            _context = context;
        }

        // GET: Kategoris
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.Kategoris.ToListAsync());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }

        // GET: Kategoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var kategori = await _context.Kategoris
                    .FirstOrDefaultAsync(m => m.KategoriId == id);
                if (kategori == null)
                {
                    return NotFound();
                }

                return View(kategori);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }

        // GET: Kategoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriId,Kategorinamn")] Kategori kategori)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(kategori);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(kategori);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }

        // GET: Kategoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var kategori = await _context.Kategoris.FindAsync(id);
                if (kategori == null)
                {
                    return NotFound();
                }
                return View(kategori);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }

        // POST: Kategoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategoriId,Kategorinamn")] Kategori kategori)
        {
            try
            {
                if (id != kategori.KategoriId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(kategori);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!KategoriExists(kategori.KategoriId))
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
                return View(kategori);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }

        // GET: Kategoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var kategori = await _context.Kategoris
                    .FirstOrDefaultAsync(m => m.KategoriId == id);
                if (kategori == null)
                {
                    return NotFound();
                }

                return View(kategori);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }

        // POST: Kategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var kategori = await _context.Kategoris.FindAsync(id);
                _context.Kategoris.Remove(kategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }

        private bool KategoriExists(int id)
        {
            return _context.Kategoris.Any(e => e.KategoriId == id);
        }
    }
}
