using aspNetCoreEscuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreEscuela.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignaturas = getAsignaturas();

            return View(asignaturas[0]);
        }

        public IActionResult MultiAsignatura()
        {
            var asignaturas = getAsignaturas();

            return View(asignaturas);
        }

        public IActionResult MultiAsignaturaPartial()
        {
            var asignaturas = getAsignaturas();

            return View(asignaturas);
        }

        private List<Asignatura> getAsignaturas()
        {
            var listaAsignaturas = new List<Asignatura>(){
                new Asignatura{Nombre="Matemáticas",
                    UniqueId= Guid.NewGuid().ToString()
                } ,
                new Asignatura{Nombre="Educación Física",
                    UniqueId= Guid.NewGuid().ToString()
                },
                new Asignatura{Nombre="Castellano",
                    UniqueId= Guid.NewGuid().ToString()
                },
                new Asignatura{Nombre="Ciencias Naturales",
                    UniqueId= Guid.NewGuid().ToString()
                }
                ,
                new Asignatura{Nombre="Programación",
                    UniqueId= Guid.NewGuid().ToString()
                }
            };

            return listaAsignaturas;
        }
    }
}