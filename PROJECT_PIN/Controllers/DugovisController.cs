using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJECT_PIN.Data;
using PROJECT_PIN.Models;

namespace PROJECT_PIN.Controllers
{
    public class DugovisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DugovisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dugovis
        [Authorize()]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dugovi.ToListAsync());
        }

        // GET: Dugovis/Details/5
        [Authorize()]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dugovi = await _context.Dugovi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dugovi == null)
            {
                return NotFound();
            }

            return View(dugovi);
        }

        // GET: Dugovis/Create
        [Authorize()]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Dugovis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Banka,Iznos,OIB,DatumRođenja,AdresaStanovanja,KontaktBroj")] Dugovi dugovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dugovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dugovi);
        }

        // GET: Dugovis/Edit/5
        [Authorize()]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dugovi = await _context.Dugovi.FindAsync(id);
            if (dugovi == null)
            {
                return NotFound();
            }
            return View(dugovi);
        }

        // POST: Dugovis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Banka,Iznos,OIB,DatumRođenja,AdresaStanovanja,KontaktBroj")] Dugovi dugovi)
        {
            if (id != dugovi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dugovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DugoviExists(dugovi.Id))
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
            return View(dugovi);
        }

        // GET: Dugovis/Delete/5
        [Authorize()]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dugovi = await _context.Dugovi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dugovi == null)
            {
                return NotFound();
            }

            return View(dugovi);
        }

        // POST: Dugovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dugovi = await _context.Dugovi.FindAsync(id);
            _context.Dugovi.Remove(dugovi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DugoviExists(int id)
        {
            return _context.Dugovi.Any(e => e.Id == id);
        }
    }
}
