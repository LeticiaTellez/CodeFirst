using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Grado
    {
        public int GradoId { get; set; }
        public string Nombre { get; set; }
        public string Seccion { get; set; }
        public bool Estado { get; set; }

        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
