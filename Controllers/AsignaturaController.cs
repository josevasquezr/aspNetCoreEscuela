using aspNetCoreEscuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreEscuela.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context { get; set; }

        public AsignaturaController(EscuelaContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var asignaturas = _context.Asignaturas.FirstOrDefault();

            return View(asignaturas);
        }

        public IActionResult MultiAsignatura()
        {
            var asignaturas = _context.Asignaturas;

            return View(asignaturas);
        }

        public IActionResult MultiAsignaturaPartial()
        {
            var asignaturas = _context.Asignaturas;

            return View(asignaturas);
        }
    }
}