using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal? Estatura { get; set; }
        public decimal? Peso { get; set; }
        public bool Estado { get; set; }

        public int GradoId { get; set; }
        public Grado Grado { get; set; }
    }
}
