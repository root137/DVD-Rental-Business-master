#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DVDRental.Models;

namespace DVDRental.Controllers
{
    public class DVDCategoriesController : Controller
    {
        private readonly DataBaseContext _context;

        public DVDCategoriesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: DVDCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.DVDCategory.ToListAsync());
        }

        // GET: DVDCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVDCategory = await _context.DVDCategory
                .FirstOrDefaultAsync(m => m.CategoryNumber == id);
            if (dVDCategory == null)
            {
                return NotFound();
            }

            return View(dVDCategory);
        }

        // GET: DVDCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DVDCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryNumber,CategoryDescription,AgeRestricted")] DVDCategory dVDCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dVDCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dVDCategory);
        }

        // GET: DVDCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVDCategory = await _context.DVDCategory.FindAsync(id);
            if (dVDCategory == null)
            {
                return NotFound();
            }
            return View(dVDCategory);
        }

        // POST: DVDCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryNumber,CategoryDescription,AgeRestricted")] DVDCategory dVDCategory)
        {
            if (id != dVDCategory.CategoryNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dVDCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVDCategoryExists(dVDCategory.CategoryNumber))
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
            return View(dVDCategory);
        }

        // GET: DVDCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVDCategory = await _context.DVDCategory
                .FirstOrDefaultAsync(m => m.CategoryNumber == id);
            if (dVDCategory == null)
            {
                return NotFound();
            }

            return View(dVDCategory);
        }

        // POST: DVDCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dVDCategory = await _context.DVDCategory.FindAsync(id);
            _context.DVDCategory.Remove(dVDCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DVDCategoryExists(int id)
        {
            return _context.DVDCategory.Any(e => e.CategoryNumber == id);
        }
    }
}
