using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace aspNetCoreEscuela.Models
{
    public class Asignatura
    {
        public Guid AsignaturaID { get; set; }
        public Guid CursoID { get; set; }
        public string Nombre { get; set; }

        [ValidateNever]
        public virtual Curso Curso { get; set; }

        [ValidateNever]
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }
    }
}