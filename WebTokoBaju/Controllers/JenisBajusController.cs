using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTokoBaju.Data;

namespace WebTokoBaju.Controllers
{
    public class JenisBajusController : Controller
    {
        private readonly MysqlDBContext _context;

        public JenisBajusController(MysqlDBContext context)
        {
            _context = context;
        }

        // GET: JenisBajus
        public async Task<IActionResult> Index()
        {
              return _context.JenisBajus != null ? 
                          View(await _context.JenisBajus.ToListAsync()) :
                          Problem("Entity set 'MysqlDBContext.JenisBajus'  is null.");
        }

        // GET: JenisBajus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JenisBajus == null)
            {
                return NotFound();
            }

            var jenisBaju = await _context.JenisBajus
                .FirstOrDefaultAsync(m => m.IdJenisBaju == id);
            if (jenisBaju == null)
            {
                return NotFound();
            }

            return View(jenisBaju);
        }

        // GET: JenisBajus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisBajus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJenisBaju,NamaJenisBaju")] JenisBaju jenisBaju)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jenisBaju);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jenisBaju);
        }

        // GET: JenisBajus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JenisBajus == null)
            {
                return NotFound();
            }

            var jenisBaju = await _context.JenisBajus.FindAsync(id);
            if (jenisBaju == null)
            {
                return NotFound();
            }
            return View(jenisBaju);
        }

        // POST: JenisBajus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJenisBaju,NamaJenisBaju")] JenisBaju jenisBaju)
        {
            if (id != jenisBaju.IdJenisBaju)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jenisBaju);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JenisBajuExists(jenisBaju.IdJenisBaju))
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
            return View(jenisBaju);
        }

        // GET: JenisBajus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JenisBajus == null)
            {
                return NotFound();
            }

            var jenisBaju = await _context.JenisBajus
                .FirstOrDefaultAsync(m => m.IdJenisBaju == id);
            if (jenisBaju == null)
            {
                return NotFound();
            }

            return View(jenisBaju);
        }

        // POST: JenisBajus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JenisBajus == null)
            {
                return Problem("Entity set 'MysqlDBContext.JenisBajus'  is null.");
            }
            var jenisBaju = await _context.JenisBajus.FindAsync(id);
            if (jenisBaju != null)
            {
                _context.JenisBajus.Remove(jenisBaju);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JenisBajuExists(int id)
        {
          return (_context.JenisBajus?.Any(e => e.IdJenisBaju == id)).GetValueOrDefault();
        }
    }
}
