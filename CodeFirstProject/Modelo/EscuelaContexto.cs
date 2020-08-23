using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EscuelaContexto : DbContext
    {
        public EscuelaContexto() : base("EscuelaDB")
        {

        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Grado> Grados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .Property(p => p.Nombre)
                .IsRequired();

            modelBuilder.Entity<Grado>()
                .Property(p => p.Nombre)
                .IsRequired();
        }
    }
}
