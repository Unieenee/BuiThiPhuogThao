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
    public class DaiLyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DaiLyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DaiLy
        public async Task<IActionResult> Index()
        {
            return View(await _context.DaiLies.ToListAsync());
        }

        // GET: DaiLy/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daiLy = await _context.DaiLies
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (daiLy == null)
            {
                return NotFound();
            }

            return View(daiLy);
        }

        // GET: DaiLy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DaiLy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHTPP,MaDaiLy,TenDaiLy,Diachi,NguoiDaiDien,DienThoai")] DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daiLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daiLy);
        }

        // GET: DaiLy/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daiLy = await _context.DaiLies.FindAsync(id);
            if (daiLy == null)
            {
                return NotFound();
            }
            return View(daiLy);
        }

        // POST: DaiLy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHTPP,MaDaiLy,TenDaiLy,Diachi,NguoiDaiDien,DienThoai")] DaiLy daiLy)
        {
            if (id != daiLy.MaHTPP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daiLy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaiLyExists(daiLy.MaHTPP))
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
            return View(daiLy);
        }

        // GET: DaiLy/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daiLy = await _context.DaiLies
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (daiLy == null)
            {
                return NotFound();
            }

            return View(daiLy);
        }

        // POST: DaiLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var daiLy = await _context.DaiLies.FindAsync(id);
            if (daiLy != null)
            {
                _context.DaiLies.Remove(daiLy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaiLyExists(string id)
        {
            return _context.DaiLies.Any(e => e.MaHTPP == id);
        }
    }
}
