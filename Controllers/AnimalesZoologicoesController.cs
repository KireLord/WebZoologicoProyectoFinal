using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebZoologico.Data;
using WebZoologico.Models;

namespace WebZoologico.Controllers
{
    public class AnimalesZoologicoesController : Controller
    {
        private readonly WebZoologicoContext _context;

        public AnimalesZoologicoesController(WebZoologicoContext context)
        {
            _context = context;
        }

        // GET: AnimalesZoologicoes
        public async Task<IActionResult> Index()
        {
              return _context.AnimalesZoologico != null ? 
                          View(await _context.AnimalesZoologico.ToListAsync()) :
                          Problem("Entity set 'WebZoologicoContext.AnimalesZoologico'  is null.");
        }

        // GET: AnimalesZoologicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnimalesZoologico == null)
            {
                return NotFound();
            }

            var animalesZoologico = await _context.AnimalesZoologico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalesZoologico == null)
            {
                return NotFound();
            }

            return View(animalesZoologico);
        }

        // GET: AnimalesZoologicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalesZoologicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Especie,Descripcion,FotoPath")] AnimalesZoologico animalesZoologico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalesZoologico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalesZoologico);
        }

        // GET: AnimalesZoologicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnimalesZoologico == null)
            {
                return NotFound();
            }

            var animalesZoologico = await _context.AnimalesZoologico.FindAsync(id);
            if (animalesZoologico == null)
            {
                return NotFound();
            }
            return View(animalesZoologico);
        }

        // POST: AnimalesZoologicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Especie,Descripcion,FotoPath")] AnimalesZoologico animalesZoologico)
        {
            if (id != animalesZoologico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalesZoologico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalesZoologicoExists(animalesZoologico.Id))
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
            return View(animalesZoologico);
        }

        // GET: AnimalesZoologicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnimalesZoologico == null)
            {
                return NotFound();
            }

            var animalesZoologico = await _context.AnimalesZoologico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalesZoologico == null)
            {
                return NotFound();
            }

            return View(animalesZoologico);
        }

        // POST: AnimalesZoologicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnimalesZoologico == null)
            {
                return Problem("Entity set 'WebZoologicoContext.AnimalesZoologico'  is null.");
            }
            var animalesZoologico = await _context.AnimalesZoologico.FindAsync(id);
            if (animalesZoologico != null)
            {
                _context.AnimalesZoologico.Remove(animalesZoologico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalesZoologicoExists(int id)
        {
          return (_context.AnimalesZoologico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
