using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace RufatRashidov.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IndexHomesController : Controller
    {
        private readonly DbPortfolio _context;
        private IWebHostEnvironment _environment;

        public IndexHomesController(DbPortfolio context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/IndexHomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndexHome.ToListAsync());
        }

        // GET: Admin/IndexHomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexHome = await _context.IndexHome
                .FirstOrDefaultAsync(m => m.ID == id);
            if (indexHome == null)
            {
                return NotFound();
            }

            return View(indexHome);
        }

        // GET: Admin/IndexHomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/IndexHomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Header,Name,WebArea,Photo,ID,ModifiedOn")] IndexHome indexHome,IFormFile Photos)
        {
            if (Photos != null)
            {
                var FileName = Guid.NewGuid() + Photos.FileName;
                var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                var imgFolder = Path.Combine(wwwFolder, FileName);
                using var fileStream = new FileStream(imgFolder, FileMode.Create);
                Photos.CopyTo(fileStream);
                indexHome.Photo = "/img/" + FileName;
            }
            if (ModelState.IsValid)
            {
               
                _context.Add(indexHome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indexHome);
        }

        // GET: Admin/IndexHomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexHome = await _context.IndexHome.FindAsync(id);
            if (indexHome == null)
            {
                return NotFound();
            }
            return View(indexHome);
        }

        // POST: Admin/IndexHomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Header,Name,WebArea,Photo,ID,ModifiedOn")] IndexHome indexHome,IFormFile Photo)
        {
            if (id != indexHome.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var FileName = Guid.NewGuid() + Photo.FileName;
                var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                var imgFolder = Path.Combine(wwwFolder, FileName);
                using var fileStream = new FileStream(imgFolder, FileMode.Create);
                Photo.CopyTo(fileStream);
                indexHome.Photo = "/img/" + FileName;
                try
                {
                    _context.Update(indexHome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndexHomeExists(indexHome.ID))
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
            return View(indexHome);
        }

        // GET: Admin/IndexHomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexHome = await _context.IndexHome
                .FirstOrDefaultAsync(m => m.ID == id);
            if (indexHome == null)
            {
                return NotFound();
            }

            return View(indexHome);
        }

        // POST: Admin/IndexHomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indexHome = await _context.IndexHome.FindAsync(id);
            _context.IndexHome.Remove(indexHome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndexHomeExists(int id)
        {
            return _context.IndexHome.Any(e => e.ID == id);
        }
    }
}
