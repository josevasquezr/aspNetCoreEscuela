using aspNetCoreEscuela.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace aspNetCoreEscuela.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context { get; set; }
        public IActionResult Index(){
            Escuela escuela = new Escuela();

            escuela = _context.Escuelas.FirstOrDefault<Escuela>();

            return View(escuela);
        }

        public EscuelaController(EscuelaContext context)
        {
            this._context = context;
        }
    }
}