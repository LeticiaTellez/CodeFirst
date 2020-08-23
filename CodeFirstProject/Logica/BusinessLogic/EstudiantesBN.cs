using Logica.DataTransferObjects;
using Modelo;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.BusinessLogic
{
    public class EstudiantesBN
    {
        public List<EstudiantesDTO> Listar()
        {
            using (EscuelaContexto db = new EscuelaContexto())
            {
                return db.Estudiantes
                    .Select(s => new EstudiantesDTO
                    {
                        EstudianteId = s.EstudianteId,
                        Nombre = s.Nombre,
                        FechaNacimiento = s.FechaNacimiento,
                        Estatura = s.Estatura,
                        Peso = s.Peso,
                        GradoNombre = s.Grado.Nombre,
                        GradoId = s.GradoId
                    }).ToList();
            }
        }

        public bool Guardar(EstudiantesDTO modelo, ref string error)
        {
            using (EscuelaContexto db = new EscuelaContexto())
            {
                try
                {
                    Estudiante entidad = new Estudiante
                    {
                        Nombre = modelo.Nombre,
                        FechaNacimiento = modelo.FechaNacimiento,
                        Estatura = modelo.Estatura,
                        Peso = modelo.Peso,
                        GradoId = modelo.GradoId, 
                        Estado = true
                    };

                    db.Estudiantes.Add(entidad);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public bool Editar(EstudiantesDTO modelo, ref string error)
        {
            using (EscuelaContexto db = new EscuelaContexto())
            {
                try
                {
                    Estudiante entidad = db.Estudiantes.Find(modelo.EstudianteId);
                    if (entidad == null) { error = "Registro no encontrado"; return false; }

                    entidad.Nombre = modelo.Nombre;
                    entidad.FechaNacimiento = modelo.FechaNacimiento;
                    entidad.Estatura = modelo.Estatura;
                    entidad.Peso = modelo.Peso;
                    entidad.GradoId = modelo.GradoId;

                    db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public bool Eliminar(int estudianteId, ref string error)
        {
            using (EscuelaContexto db = new EscuelaContexto())
            {
                try
                {
                    Estudiante entidad = db.Estudiantes.Find(estudianteId);
                    if (entidad == null) { error = "Registro no encontrado"; return false; }

                    entidad.Estado = false;

                    db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }
    }
}
