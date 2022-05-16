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
    public class EvaluacionController : Controller
    {
        private readonly EscuelaContext _context;

        public EvaluacionController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Evaluacion
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Evaluaciones.Include(e => e.Alumno).Include(e => e.Asignatura);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Evaluacion/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Evaluaciones == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluaciones
                .Include(e => e.Alumno)
                .Include(e => e.Asignatura)
                .FirstOrDefaultAsync(m => m.EvaluacionID == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // GET: Evaluacion/Create
        public IActionResult Create()
        {
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoID");
            ViewData["AsignaturaID"] = new SelectList(_context.Asignaturas, "AsignaturaID", "AsignaturaID");
            return View();
        }

        // POST: Evaluacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluacionID,Nombre,Nota,AlumnoID,AsignaturaID")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoID", evaluacion.AlumnoID);
            ViewData["AsignaturaID"] = new SelectList(_context.Asignaturas, "AsignaturaID", "AsignaturaID", evaluacion.AsignaturaID);
            return View(evaluacion);
        }

        // GET: Evaluacion/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Evaluaciones == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoID", evaluacion.AlumnoID);
            ViewData["AsignaturaID"] = new SelectList(_context.Asignaturas, "AsignaturaID", "AsignaturaID", evaluacion.AsignaturaID);
            return View(evaluacion);
        }

        // POST: Evaluacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EvaluacionID,Nombre,Nota,AlumnoID,AsignaturaID")] Evaluacion evaluacion)
        {
            if (id != evaluacion.EvaluacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionExists(evaluacion.EvaluacionID))
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
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoID", evaluacion.AlumnoID);
            ViewData["AsignaturaID"] = new SelectList(_context.Asignaturas, "AsignaturaID", "AsignaturaID", evaluacion.AsignaturaID);
            return View(evaluacion);
        }

        // GET: Evaluacion/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Evaluaciones == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluaciones
                .Include(e => e.Alumno)
                .Include(e => e.Asignatura)
                .FirstOrDefaultAsync(m => m.EvaluacionID == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // POST: Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Evaluaciones == null)
            {
                return Problem("Entity set 'EscuelaContext.Evaluaciones'  is null.");
            }
            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion != null)
            {
                _context.Evaluaciones.Remove(evaluacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionExists(string id)
        {
          return (_context.Evaluaciones?.Any(e => e.EvaluacionID == id)).GetValueOrDefault();
        }
    }
}
