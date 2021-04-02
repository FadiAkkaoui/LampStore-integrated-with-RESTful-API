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
    public class ArtiklarsController : ControllerBase
    {
        private readonly LagerContext _context;

        public ArtiklarsController(LagerContext context)
        {
            _context = context;
        }

        // GET: api/Artiklars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artiklar>>> GetArtiklars()
        {
            return await _context.Artiklars.ToListAsync();
        }

        // GET: api/Artiklars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artiklar>> GetArtiklar(int id)
        {
            try
            {
                var artiklar = await _context.Artiklars.FindAsync(id);

                if (artiklar == null)
                {
                    return NotFound();
                }

                return artiklar;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }
        [Route("[controller]/ByKategoriId")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artiklar>>> GetArtiklarByKategoriId(int id)
        {
            try
            {
                var artiklars = await _context.Artiklars.Where(r => r.KategoriId == id).ToListAsync();

                if (artiklars.Count == 0)
                {
                    return NotFound();
                }

                return artiklars;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }

        // PUT: api/Artiklars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtiklar(int id, Artiklar artiklar)
        {
            try
            {
                if (id != artiklar.Id)
                {
                    return BadRequest();
                }

                _context.Entry(artiklar).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtiklarExists(id))
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

        // POST: api/Artiklars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artiklar>> PostArtiklar(Artiklar artiklar)
        {
            try
            {
                _context.Artiklars.Add(artiklar);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetArtiklar", new { id = artiklar.Id }, artiklar);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }

        // DELETE: api/Artiklars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtiklar(int id)
        {
            try
            {
                var artiklar = await _context.Artiklars.FindAsync(id);
                if (artiklar == null)
                {
                    return NotFound();
                }

                _context.Artiklars.Remove(artiklar);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Index", "Felhanterings");
            }
        }

        private bool ArtiklarExists(int id)
        {

                return _context.Artiklars.Any(e => e.Id == id);

        }
    }
}
