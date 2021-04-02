using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreDBAPI.Model;

namespace CoreDBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KategorisController : ControllerBase
    {
        private readonly LagerContext _context;

        public KategorisController(LagerContext context)
        {
            _context = context;
        }

        // GET: api/Kategoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategori>>> GetKategori()
        {
            return await _context.Kategori.ToListAsync();
        }

        // GET: api/Kategoris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategori>> GetKategori(int id)
        {
            try
            {
                var kategori = await _context.Kategori.FindAsync(id);

                if (kategori == null)
                {
                    return NotFound();
                }

                return kategori;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }

        // PUT: api/Kategoris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategori(int id, Kategori kategori)
        {
            try
            {
                if (id != kategori.KategoriId)
                {
                    return BadRequest();
                }

                _context.Entry(kategori).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }

        // POST: api/Kategoris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategori>> PostKategori(Kategori kategori)
        {
            try
            {
                _context.Kategori.Add(kategori);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetKategori", new { id = kategori.KategoriId }, kategori);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }

        // DELETE: api/Kategoris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategori(int id)
        {
            try
            {
                var kategori = await _context.Kategori.FindAsync(id);
                if (kategori == null)
                {
                    return NotFound();
                }

                _context.Kategori.Remove(kategori);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }

        private bool KategoriExists(int id)
        {
            return _context.Kategori.Any(e => e.KategoriId == id);
        }
    }
}
