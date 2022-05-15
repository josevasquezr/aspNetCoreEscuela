using System;
using System.Collections.Generic;

namespace aspNetCoreEscuela.Models
{
    public class Alumno
    {
        public string AlumnoID { get; set; }
        public string Nombre { get; set; }
        public string CursoID { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}