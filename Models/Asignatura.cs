using System;

namespace aspNetCoreEscuela.Models
{
    public class Asignatura
    {
        public string AsignaturaID { get; set; }
        public string Nombre { get; set; }
        public string CursoID { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
        public Asignatura() : base()
        {
            
        }


    }
}