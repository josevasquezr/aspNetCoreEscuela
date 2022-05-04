using aspNetCoreEscuela.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace aspNetCoreEscuela.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context { get; set; }

        public AsignaturaController(EscuelaContext context)
        {
            this._context = context;
        }
        // Actions
        [Route("Asignatura/Index/{asignaturaId?}")]
        public IActionResult Index(string asignaturaId)
        {
            if(!String.IsNullOrEmpty(asignaturaId)){
                var asignatura = from asig in _context.Asignaturas
                            where asig.Id == asignaturaId
                            select asig;

                return View(asignatura.SingleOrDefault());
            }else{
                var asignaturas = _context.Asignaturas;

                return View("MultiAsignatura", asignaturas);
            }
            
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