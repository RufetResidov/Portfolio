using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Entities;

namespace RufatRashidov.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CodingSkillsController : Controller
    {
        private readonly DbPortfolio _context;

        public CodingSkillsController(DbPortfolio context)
        {
            _context = context;
        }

        // GET: Admin/CodingSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodingSkill.ToListAsync());
        }

        // GET: Admin/CodingSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codingSkill = await _context.CodingSkill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (codingSkill == null)
            {
                return NotFound();
            }

            return View(codingSkill);
        }

        // GET: Admin/CodingSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CodingSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramName,Price,ID,ModifiedOn")] CodingSkill codingSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codingSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codingSkill);
        }

        // GET: Admin/CodingSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codingSkill = await _context.CodingSkill.FindAsync(id);
            if (codingSkill == null)
            {
                return NotFound();
            }
            return View(codingSkill);
        }

        // POST: Admin/CodingSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramName,Price,ID,ModifiedOn")] CodingSkill codingSkill)
        {
            if (id != codingSkill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codingSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodingSkillExists(codingSkill.ID))
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
            return View(codingSkill);
        }

        // GET: Admin/CodingSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codingSkill = await _context.CodingSkill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (codingSkill == null)
            {
                return NotFound();
            }

            return View(codingSkill);
        }

        // POST: Admin/CodingSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codingSkill = await _context.CodingSkill.FindAsync(id);
            _context.CodingSkill.Remove(codingSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodingSkillExists(int id)
        {
            return _context.CodingSkill.Any(e => e.ID == id);
        }
    }
}
