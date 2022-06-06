using System;

namespace aspNetCoreEscuela.Models
{
    public class Asignatura
    {
        public Guid AsignaturaID { get; set; }
        public Guid CursoID { get; set; }
        public string Nombre { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }
    }
}