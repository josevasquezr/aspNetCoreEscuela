using Microsoft.EntityFrameworkCore;

namespace aspNetCoreEscuela.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creacion de data semilla
            var escuelaSeed = CargarEscuela();
            var cursos = CargarCursos(escuelaSeed);
            var asignaturas = CargarAsignaturas(cursos);
            var alumnos = CargarAlumnos(cursos);
            
            modelBuilder.Entity<Escuela>(escuela => {
                escuela.ToTable("Escuela");
                escuela.HasKey(p => p.EscuelaID);
                escuela.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                escuela.Property(p => p.Pais).IsRequired().HasMaxLength(100);
                escuela.Property(p => p.Ciudad).IsRequired().HasMaxLength(100);
                escuela.Property(p => p.Direccion).IsRequired().HasMaxLength(300);
                escuela.Property(p => p.AnioDeCreacion).IsRequired().HasMaxLength(4);
                escuela.Property(p => p.TipoEscuela).IsRequired().HasMaxLength(1);
                escuela.HasData(escuelaSeed);
            });

            modelBuilder.Entity<Curso>(curso => {
                curso.ToTable("Curso");
                curso.HasKey(p => p.CursoID);
                curso.HasOne(p => p.Escuela)
                        .WithMany(p => p.Cursos)
                        .HasForeignKey(p => p.EscuelaID);
                curso.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                curso.Property(p => p.Jornada).IsRequired().HasMaxLength(1);
                curso.HasData(cursos);
            });

            modelBuilder.Entity<Alumno>(alumno => {
                alumno.ToTable("Alumno");
                alumno.HasKey(p => p.AlumnoID);
                alumno.HasOne(p => p.Curso)
                        .WithMany(p => p.Alumnos)
                        .HasForeignKey(p => p.CursoID);
                alumno.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
                alumno.HasData(alumnos);
            });

            modelBuilder.Entity<Asignatura>(asignatura => {
                asignatura.ToTable("Asignatura");
                asignatura.HasKey(p => p.AsignaturaID);
                asignatura.HasOne(p => p.Curso)
                            .WithMany(p => p.Asignaturas)
                            .HasForeignKey(p => p.CursoID);
                asignatura.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                asignatura.HasData(asignaturas);
            });

            modelBuilder.Entity<Evaluacion>(evaluacion => {
                evaluacion.ToTable("Evaluacion");
                evaluacion.HasKey(p => p.EvaluacionID);
                evaluacion.HasOne(p => p.Alumno)
                            .WithMany(p => p.Evaluaciones)
                            .HasForeignKey(p => p.AlumnoID);
                evaluacion.HasOne(p => p.Asignatura)
                            .WithMany(p => p.Evaluaciones)
                            .HasForeignKey(p => p.AsignaturaID)
                            .OnDelete(DeleteBehavior.NoAction);
                evaluacion.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                evaluacion.Property(p => p.Nota).IsRequired().HasMaxLength(4);
                //evaluacion.HasData(evaluaciones);
            });
        }

        private Escuela CargarEscuela()
        {
            return new Escuela(){
                EscuelaID = Guid.NewGuid(),
                Nombre = "Platzi School",
                AnioDeCreacion = 2005,
                Ciudad = "Bogota",
                Pais = "Colombia",
                Direccion = "Avd Siempre viva",
                TipoEscuela = TiposEscuela.Secundaria
            };
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura> {
                            new Asignatura{AsignaturaID = Guid.NewGuid(), CursoID = curso.CursoID, Nombre="Matemáticas"} ,
                            new Asignatura{AsignaturaID = Guid.NewGuid(), CursoID = curso.CursoID, Nombre="Educación Física"},
                            new Asignatura{AsignaturaID = Guid.NewGuid(), CursoID = curso.CursoID, Nombre="Castellano"},
                            new Asignatura{AsignaturaID = Guid.NewGuid(), CursoID = curso.CursoID, Nombre="Ciencias Naturales"},
                            new Asignatura{AsignaturaID = Guid.NewGuid(), CursoID = curso.CursoID, Nombre="Programación"}

                };
                listaCompleta.AddRange(tmpList);
            }

            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso() {CursoID = Guid.NewGuid(), EscuelaID = escuela.EscuelaID, Nombre = "101", Jornada = TiposJornada.Mañana},
                        new Curso() {CursoID = Guid.NewGuid(), EscuelaID = escuela.EscuelaID, Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso() {CursoID = Guid.NewGuid(), EscuelaID = escuela.EscuelaID, Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso() {CursoID = Guid.NewGuid(), EscuelaID = escuela.EscuelaID, Nombre = "401", Jornada = TiposJornada.Tarde},
                        new Curso() {CursoID = Guid.NewGuid(), EscuelaID = escuela.EscuelaID, Nombre = "501", Jornada = TiposJornada.Tarde},
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(
            Curso curso,
            int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoID = curso.CursoID,
                                   Nombre = $"{n1} {n2} {a1}",
                                   AlumnoID = Guid.NewGuid()
                               };

            return listaAlumnos.OrderBy((al) => al.AlumnoID).Take(cantidad).ToList();
        }
    }
}