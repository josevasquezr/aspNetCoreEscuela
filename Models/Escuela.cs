using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace aspNetCoreEscuela.Models
{
    public class Escuela
    {
        public Guid EscuelaID { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public int AnioDeCreacion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        [ValidateNever]
        public virtual ICollection<Curso> Cursos { get; set; }

    }
}
