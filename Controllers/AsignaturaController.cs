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
                            where asig.AsignaturaID == asignaturaId
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
        
        public IActionResult Create(){

            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            asignatura.AsignaturaID = Guid.NewGuid().ToString();
            var curso = _context.Cursos.FirstOrDefault();
            asignatura.CursoID = curso.CursoID;
            asignatura.Curso = curso;
            
            _context.Asignaturas.Add(asignatura);
            _context.SaveChanges();

            return View("Index", asignatura);
        }
    }
}