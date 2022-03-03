#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Húsüzem.Data;
using Húsüzem.Models;

namespace Húsüzem.Controllers
{
    public class HusikaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HusikaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Husika
        public async Task<IActionResult> Index()
        {
            return View(await _context.Husika.ToListAsync());
        }

        // GET: Keresés
        public async Task<IActionResult> Keresés()
        {
            return View();
        }

        // POST: KeresésEredmények
        public async Task<IActionResult> KeresésEredmények(String keresettszo)
        {
            
            return View("Index", await _context.Husika.Where(j => j.Terméknév.Contains(keresettszo) || j.Alapanyag.Contains(keresettszo)).ToListAsync()); 
        }

        // GET: Husika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var husika = await _context.Husika
                .FirstOrDefaultAsync(m => m.Id == id);
            if (husika == null)
            {
                return NotFound();
            }

            return View(husika);
        }

        // GET: Husika/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Husika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Terméknév,Ár,Alapanyag,GyártásIdeje")] Husika husika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(husika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(husika);
        }

        // GET: Husika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var husika = await _context.Husika.FindAsync(id);
            if (husika == null)
            {
                return NotFound();
            }
            return View(husika);
        }

        // POST: Husika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Terméknév,Ár,Alapanyag,GyártásIdeje")] Husika husika)
        {
            if (id != husika.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(husika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HusikaExists(husika.Id))
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
            return View(husika);
        }

        // GET: Husika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var husika = await _context.Husika
                .FirstOrDefaultAsync(m => m.Id == id);
            if (husika == null)
            {
                return NotFound();
            }

            return View(husika);
        }

        // POST: Husika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var husika = await _context.Husika.FindAsync(id);
            _context.Husika.Remove(husika);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HusikaExists(int id)
        {
            return _context.Husika.Any(e => e.Id == id);
        }
    }
}
