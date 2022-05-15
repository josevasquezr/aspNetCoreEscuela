using aspNetCoreEscuela.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace aspNetCoreEscuela.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context { get; set; }

        public CursoController(EscuelaContext context)
        {
            this._context = context;
        }

        [Route("Curso/{Id?}")]
        public IActionResult Index(string Id)
        {
            ViewBag.Mensaje = "";

            if (String.IsNullOrEmpty(Id))
            {
                return View("Lista", _context.Cursos);
            }
            else
            {
                var curso = from cur in _context.Cursos
                            where cur.CursoID == Id
                            select cur;

                return View(curso.SingleOrDefault());
            }
        }

        [HttpGet]
        [Route("Curso/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost]
        // [Route("Curso/Create")]
        // public IActionResult Create(Curso curso){
        //     Escuela escuela = _context.Escuelas.FirstOrDefault();
        //     curso.CursoID = Guid.NewGuid().ToString();
        //     curso.EscuelaID = escuela.EscuelaID;

        //     if (ModelState.IsValid)
        //     {
        //         _context.Cursos.Add(curso);
        //         _context.SaveChanges();

        //         ViewBag.Mensaje = "Curso creado exitosamente";

        //         return View("Index", curso);
        //     }else{
        //         return View(curso);
        //     }

        // }

        [HttpPost]
        [Route("Curso/Create")]
        public IActionResult Create(Curso curso)
        {
            Escuela escuela = _context.Escuelas.FirstOrDefault();
            curso.CursoID = Guid.NewGuid().ToString();
            curso.EscuelaID = escuela.EscuelaID;

            _context.Cursos.Add(curso);
            _context.SaveChanges();

            ViewBag.Mensaje = "Curso creado exitosamente";

            return View("Index", curso);

        }
    }
}