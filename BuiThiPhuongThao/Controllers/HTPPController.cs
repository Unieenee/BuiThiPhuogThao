using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HTPPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HTPPController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HTPP
        public async Task<IActionResult> Index()
        {
            return View(await _context.HTPPs.ToListAsync());
        }

        // GET: HTPP/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hTPP = await _context.HTPPs
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (hTPP == null)
            {
                return NotFound();
            }

            return View(hTPP);
        }

        // GET: HTPP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HTPP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHTPP,TenHTPP")] HTPP hTPP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hTPP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hTPP);
        }

        // GET: HTPP/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hTPP = await _context.HTPPs.FindAsync(id);
            if (hTPP == null)
            {
                return NotFound();
            }
            return View(hTPP);
        }

        // POST: HTPP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHTPP,TenHTPP")] HTPP hTPP)
        {
            if (id != hTPP.MaHTPP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hTPP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HTPPExists(hTPP.MaHTPP))
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
            return View(hTPP);
        }

        // GET: HTPP/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hTPP = await _context.HTPPs
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (hTPP == null)
            {
                return NotFound();
            }

            return View(hTPP);
        }

        // POST: HTPP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hTPP = await _context.HTPPs.FindAsync(id);
            if (hTPP != null)
            {
                _context.HTPPs.Remove(hTPP);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HTPPExists(string id)
        {
            return _context.HTPPs.Any(e => e.MaHTPP == id);
        }
    }
}
