using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspNetCoreEscuela.Models
{
    public class Curso
    {
        public Guid CursoID { get; set; }
        public Guid EscuelaID { get; set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual ICollection<Asignatura> Asignaturas{ get; set; }
        public virtual ICollection<Alumno> Alumnos{ get; set; }

    }
}