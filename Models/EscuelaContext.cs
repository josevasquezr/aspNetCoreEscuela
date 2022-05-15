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

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.EscuelaID = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.AnioDeCreacion = 2005;
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Direccion = "Avd Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            
            //Cargar Cursos de la escuela
            var cursos = CargarCursos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);
            
            //modelBuilder.Entity<Escuela>().HasMany(p => p.Cursos).WithOne(b => b.Escuela);
            //modelBuilder.Entity<Curso>().HasMany(p => p.Alumnos).WithOne(b => b.Curso);
            //modelBuilder.Entity<Curso>().HasMany(p => p.Asignaturas).WithOne(b => b.Curso);
            //modelBuilder.Entity<Asignatura>().HasMany(p => p.Evaluaciones).WithOne(b => b.Asignatura);
            //modelBuilder.Entity<Alumno>().HasMany(p => p.Evaluaciones).WithOne(b => b.Alumno);
//
            //modelBuilder.Entity<Escuela>().Navigation(e => e.Cursos).UsePropertyAccessMode(PropertyAccessMode.Property);
            //modelBuilder.Entity<Curso>().Navigation(c => c.Alumnos).UsePropertyAccessMode(PropertyAccessMode.Property);
            //modelBuilder.Entity<Curso>().Navigation(c => c.Asignaturas).UsePropertyAccessMode(PropertyAccessMode.Property);
            //modelBuilder.Entity<Asignatura>().Navigation(a => a.Evaluaciones).UsePropertyAccessMode(PropertyAccessMode.Property);
            //modelBuilder.Entity<Alumno>().Navigation(a => a.Evaluaciones).UsePropertyAccessMode(PropertyAccessMode.Property);

            //modelBuilder.Entity<Escuela>().ToTable("Escuela").HasData(escuela);
            //modelBuilder.Entity<Curso>().ToTable("Curso").HasData(cursos.ToArray());
            //modelBuilder.Entity<Asignatura>().ToTable("Asignatura").HasData(asignaturas.ToArray());
            //modelBuilder.Entity<Alumno>().ToTable("Alumno").HasData(alumnos.ToArray());

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
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
                            new Asignatura{AsignaturaID = Guid.NewGuid().ToString(), CursoID = curso.CursoID, Nombre="Matemáticas"} ,
                            new Asignatura{AsignaturaID = Guid.NewGuid().ToString(), CursoID = curso.CursoID, Nombre="Educación Física"},
                            new Asignatura{AsignaturaID = Guid.NewGuid().ToString(), CursoID = curso.CursoID, Nombre="Castellano"},
                            new Asignatura{AsignaturaID = Guid.NewGuid().ToString(), CursoID = curso.CursoID, Nombre="Ciencias Naturales"},
                            new Asignatura{AsignaturaID = Guid.NewGuid().ToString(), CursoID = curso.CursoID, Nombre="Programación"}

                };
                listaCompleta.AddRange(tmpList);
            }

            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso() {CursoID = Guid.NewGuid().ToString(), EscuelaID = escuela.EscuelaID, Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {CursoID = Guid.NewGuid().ToString(), EscuelaID = escuela.EscuelaID, Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso() {CursoID = Guid.NewGuid().ToString(), EscuelaID = escuela.EscuelaID, Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso() {CursoID = Guid.NewGuid().ToString(), EscuelaID = escuela.EscuelaID, Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {CursoID = Guid.NewGuid().ToString(), EscuelaID = escuela.EscuelaID, Nombre = "501", Jornada = TiposJornada.Tarde},
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
                                   AlumnoID = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.AlumnoID).Take(cantidad).ToList();
        }
    }
}