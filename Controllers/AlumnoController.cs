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
    public class AlumnoController : Controller
    {
        private readonly EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Alumno
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Alumnos.Include(a => a.Curso);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Alumno/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(m => m.AlumnoID == id);

            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumno/Create
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre");
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre, CursoID")] Alumno alumno)
        {
            alumno.AlumnoID = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre", alumno.CursoID);

            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre", alumno.CursoID);

            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AlumnoID, Nombre, CursoID")] Alumno alumno)
        {
            if (id != alumno.AlumnoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.AlumnoID))
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

            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Nombre", alumno.CursoID);

            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(m => m.AlumnoID == id);

            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Alumnos == null)
            {
                return Problem("Entity set 'EscuelaContext.Alumnos'  is null.");
            }
            var alumno = await _context.Alumnos.FindAsync(id);
            
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(Guid id)
        {
          return (_context.Alumnos?.Any(e => e.AlumnoID == id)).GetValueOrDefault();
        }
    }
}
