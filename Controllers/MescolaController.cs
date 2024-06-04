using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestioneStoccaggioMescoleIdentity.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Authorization;

namespace GestioneStoccaggioMescoleIdentity.Controllers
{
    [Authorize]
    public class MescolaController : Controller
    {
        private readonly GestioneStoccaggioMescoleIdentityContext _context;

        public MescolaController(GestioneStoccaggioMescoleIdentityContext context)
        {
            _context = context;
        }

        // GET: Mescola
        public async Task<IActionResult> Index()
        {
              return _context.Mescola != null ? 
                          View(await _context.Mescola.ToListAsync()) :
                          Problem("Entity set 'GestioneStoccaggioMescoleIdentityContext.Mescola'  is null.");
        }

        // GET: Mescola/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mescola == null)
            {
                return NotFound();
            }

            var mescola = await _context.Mescola
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mescola == null)
            {
                return NotFound();
            }

            return View(mescola);
        }

        // GET: Mescola/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mescola/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descrizione,DataProduzione,Prezzo")] Mescola mescola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mescola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mescola);
        }

        // GET: Mescola/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mescola == null)
            {
                return NotFound();
            }

            var mescola = await _context.Mescola.FindAsync(id);
            if (mescola == null)
            {
                return NotFound();
            }
            return View(mescola);
        }

        // POST: Mescola/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descrizione,DataProduzione,Prezzo")] Mescola mescola)
        {
            if (id != mescola.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mescola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MescolaExists(mescola.Id))
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
            return View(mescola);
        }

        // GET: Mescola/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mescola == null)
            {
                return NotFound();
            }

            var mescola = await _context.Mescola
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mescola == null)
            {
                return NotFound();
            }

            return View(mescola);
        }

        // POST: Mescola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mescola == null)
            {
                return Problem("Entity set 'GestioneStoccaggioMescoleIdentityContext.Mescola'  is null.");
            }
            var mescola = await _context.Mescola.FindAsync(id);
            if (mescola != null)
            {
                _context.Mescola.Remove(mescola);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MescolaExists(int id)
        {
          return (_context.Mescola?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
