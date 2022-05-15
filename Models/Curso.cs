using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspNetCoreEscuela.Models
{
    public class Curso
    {
        public string CursoID { get; set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public string EscuelaID { get; set; }
        public Escuela Escuela { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }

    }
}