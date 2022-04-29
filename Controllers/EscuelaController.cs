using aspNetCoreEscuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreEscuela.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index(){
            Escuela escuela = new Escuela();

            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi Academy";
            escuela.AnioDeCreacion = 2005;

            return View(escuela);
        }
    }
}