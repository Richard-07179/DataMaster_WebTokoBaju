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
    public class MerksController : Controller
    {
        private readonly MysqlDBContext _context;

        public MerksController(MysqlDBContext context)
        {
            _context = context;
        }

        // GET: Merks
        public async Task<IActionResult> Index()
        {
              return _context.Merks != null ? 
                          View(await _context.Merks.ToListAsync()) :
                          Problem("Entity set 'MysqlDBContext.Merks'  is null.");
        }

        // GET: Merks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Merks == null)
            {
                return NotFound();
            }

            var merk = await _context.Merks
                .FirstOrDefaultAsync(m => m.IdMerk == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // GET: Merks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMerk,NamaMerk")] Merk merk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merk);
        }

        // GET: Merks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Merks == null)
            {
                return NotFound();
            }

            var merk = await _context.Merks.FindAsync(id);
            if (merk == null)
            {
                return NotFound();
            }
            return View(merk);
        }

        // POST: Merks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMerk,NamaMerk")] Merk merk)
        {
            if (id != merk.IdMerk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerkExists(merk.IdMerk))
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
            return View(merk);
        }

        // GET: Merks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Merks == null)
            {
                return NotFound();
            }

            var merk = await _context.Merks
                .FirstOrDefaultAsync(m => m.IdMerk == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // POST: Merks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Merks == null)
            {
                return Problem("Entity set 'MysqlDBContext.Merks'  is null.");
            }
            var merk = await _context.Merks.FindAsync(id);
            if (merk != null)
            {
                _context.Merks.Remove(merk);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerkExists(int id)
        {
          return (_context.Merks?.Any(e => e.IdMerk == id)).GetValueOrDefault();
        }
    }
}
