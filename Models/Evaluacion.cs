using System;

namespace aspNetCoreEscuela.Models
{
    public class Evaluacion
    {
        public Guid EvaluacionID { get; set; }
        public Guid AlumnoID { get; set; }
        public Guid AsignaturaID { get; set; }
        public string Nombre { get; set; }
        public float Nota { get; set; }
        public virtual Alumno Alumno { get; set; }
        public virtual Asignatura Asignatura  { get; set; }


    }
}