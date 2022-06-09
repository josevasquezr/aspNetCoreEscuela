using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspNetCoreEscuela.Models;

namespace aspNetCoreEscuela.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Asignatura
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Asignaturas.Include(a => a.Curso);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Asignatura/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(m => m.AsignaturaID == id);

            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // GET: Asignatura/Create
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre");
            return View();
        }

        // POST: Asignatura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre, CursoID")] Asignatura asignatura)
        {
            asignatura.AsignaturaID = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _context.Add(asignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre", asignatura.CursoID);

            return View(asignatura);
        }

        // GET: Asignatura/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas.FindAsync(id);

            if (asignatura == null)
            {
                return NotFound();
            }

            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre", asignatura.CursoID);

            return View(asignatura);
        }

        // POST: Asignatura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AsignaturaID, Nombre, CursoID")] Asignatura asignatura)
        {
            if (id != asignatura.AsignaturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaExists(asignatura.AsignaturaID))
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

            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre", asignatura.CursoID);

            return View(asignatura);
        }

        // GET: Asignatura/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(m => m.AsignaturaID == id);

            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // POST: Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Asignaturas == null)
            {
                return Problem("Entity set 'EscuelaContext.Asignaturas'  is null.");
            }

            var asignatura = await _context.Asignaturas.FindAsync(id);

            if (asignatura != null)
            {
                _context.Asignaturas.Remove(asignatura);
            }
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaExists(Guid id)
        {
          return (_context.Asignaturas?.Any(e => e.AsignaturaID == id)).GetValueOrDefault();
        }
    }
}
