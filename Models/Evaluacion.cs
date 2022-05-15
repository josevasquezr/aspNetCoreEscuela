using System;

namespace aspNetCoreEscuela.Models
{
    public class Evaluacion
    {
        public string EvaluacionID { get; set; }
        public string Nombre { get; set; }
        public float Nota { get; set; }
        public string AlumnoID { get; set; }
        public Alumno Alumno { get; set; }
        public string AsignaturaID { get; set; }
        public Asignatura Asignatura  { get; set; }


    }
}