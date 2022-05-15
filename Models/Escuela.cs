using System;
using System.Collections.Generic;


namespace aspNetCoreEscuela.Models
{
    public class Escuela
    {
        public string EscuelaID { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public int AnioDeCreacion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

    }
}
