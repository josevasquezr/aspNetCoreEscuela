using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace aspNetCoreEscuela.Models
{
    public class Curso
    {
        public Guid CursoID { get; set; }
        public Guid EscuelaID { get; set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }

        [ValidateNever]
        public virtual Escuela Escuela { get; set; }

        [ValidateNever]
        public virtual ICollection<Asignatura> Asignaturas{ get; set; }

        [ValidateNever]
        public virtual ICollection<Alumno> Alumnos{ get; set; }

    }
}