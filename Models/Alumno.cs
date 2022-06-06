using System;
using System.Collections.Generic;

namespace aspNetCoreEscuela.Models
{
    public class Alumno
    {
        public Guid AlumnoID { get; set; }
        public Guid CursoID { get; set; }
        public string Nombre { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }
    }
}