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
    public class BajusController : Controller
    {
        private readonly MysqlDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        string _folderSimpanGambarBaju = "gambar_baju";


        public BajusController(MysqlDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Bajus
        public async Task<IActionResult> Index()
        {
            if(_context.Bajus != null)
            {
                var bajus = await _context.Bajus
                    .Include(p=>p.MyJenisBaju)
                    .Include(p=>p.MyMerk)
                    .ToListAsync();
                return View(bajus);
            }
            else
            {
                return Problem("Entity set 'MysqlDBContext.Bajus'  is null.");
            }
        }

        // GET: Bajus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bajus == null)
            {
                return NotFound();
            }

            var baju = await _context.Bajus
                .FirstOrDefaultAsync(m => m.IdBaju == id);
            if (baju == null)
            {
                return NotFound();
            }

            return View(baju);
        }

        // GET: Bajus/Create
        public async Task<IActionResult> Create()
        {
            await InitChoice();
            return View();
        }

        // POST: Bajus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaju,NamaBaju,Harga,id_merk,id_jenis_baju,GambarBaju")] Baju baju)
        {
            if(baju.GambarBaju != null)
            {
                await SaveImage(baju);
            }

            _context.Add(baju);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Bajus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bajus == null)
            {
                return NotFound();
            }

            await InitChoice();
            var baju = await _context.Bajus.FindAsync(id);
            if (baju == null)
            {
                return NotFound();
            }
            return View(baju);
        }

        // POST: Bajus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaju,NamaBaju,Harga,id_merk,id_jenis_baju,PathGambarBaju,GambarBaju")] Baju baju)
        {
            if (id != baju.IdBaju)
            {
                return NotFound();
            }

            if (baju.GambarBaju != null)
            {
                string pathOldFile = Path.Combine(_webHostEnvironment.WebRootPath, _folderSimpanGambarBaju, baju.PathGambarBaju);
                FileInfo fileInfo = new (pathOldFile);

                await SaveImage(baju);
            }

            try
            {
                _context.Update(baju);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BajuExists(baju.IdBaju))
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

        // GET: Bajus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bajus == null)
            {
                return NotFound();
            }

            var baju = await _context.Bajus
                .FirstOrDefaultAsync(m => m.IdBaju == id);
            if (baju == null)
            {
                return NotFound();
            }

            return View(baju);
        }

        // POST: Bajus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bajus == null)
            {
                return Problem("Entity set 'MysqlDBContext.Bajus'  is null.");
            }
            var baju = await _context.Bajus.FindAsync(id);
            if (baju != null)
            {
                _context.Bajus.Remove(baju);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BajuExists(int id)
        {
          return (_context.Bajus?.Any(e => e.IdBaju == id)).GetValueOrDefault();
        }

        private async Task InitChoice()
        {
            ViewBag.Merks = await _context.Merks.ToListAsync();
            ViewBag.JenisBajus = await _context.JenisBajus.ToListAsync();
        }

        
        async Task SaveImage(Baju baju)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + baju.GambarBaju.FileName;
            string pathFile = Path.Combine(_webHostEnvironment.WebRootPath, _folderSimpanGambarBaju, fileName);

            await baju.GambarBaju.CopyToAsync(new FileStream(pathFile, FileMode.Create));

            baju.PathGambarBaju = fileName;
        }
    }
}
