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
    public class CursoController : Controller
    {
        private readonly EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Curso
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Cursos.Include(c => c.Escuela);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Curso/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Escuela)
                .FirstOrDefaultAsync(m => m.CursoID == id);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            ViewData["EscuelaID"] = new SelectList(_context.Escuelas, "EscuelaID", "Nombre");
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre, Jornada, EscuelaID")] Curso curso)
        {
            curso.CursoID = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscuelaID"] = new SelectList(_context.Escuelas, "EscuelaID", "Nombre", curso.EscuelaID);
            return View(curso);
        }

        // GET: Curso/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            ViewData["EscuelaID"] = new SelectList(_context.Escuelas, "EscuelaID", "Nombre", curso.EscuelaID);

            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CursoID, Nombre, Jornada, EscuelaID")] Curso curso)
        {
            if (id != curso.CursoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoID))
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
            ViewData["EscuelaID"] = new SelectList(_context.Escuelas, "EscuelaID", "Nombre", curso.EscuelaID);

            return View(curso);
        }

        // GET: Curso/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Escuela)
                .FirstOrDefaultAsync(m => m.CursoID == id);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Cursos == null)
            {
                return Problem("Entity set 'EscuelaContext.Cursos'  is null.");
            }

            var curso = await _context.Cursos.FindAsync(id);

            if (curso != null)
            {
                _context.Cursos.Remove(curso);
            }
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(Guid id)
        {
          return (_context.Cursos?.Any(e => e.CursoID == id)).GetValueOrDefault();
        }
    }
}
