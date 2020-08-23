using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DataTransferObjects
{
    public class EstudiantesDTO
    {
        public int? EstudianteId { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo fecha nacimiento es requerido")]
        public DateTime FechaNacimiento { get; set; }
        public decimal? Estatura { get; set; }
        public decimal? Peso { get; set; }
        [Required(ErrorMessage = "El campo grado es requerido")]
        public int GradoId { get; set; }
        public string GradoNombre { get; set; }
    }
}
