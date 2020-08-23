using Logica.BusinessLogic;
using Logica.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstProject.Controllers
{
    public class EstudiantesController : Controller
    {
        string error = string.Empty;

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerEstudiantes()
        {
            List<EstudiantesDTO> lista = new EstudiantesBN().Listar();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Formulario()
        {
            return View("_Formulario");
        }

        [HttpPost]
        public JsonResult GuardarEstudiante(EstudiantesDTO modelo)
        {
            if (ModelState.IsValid)
            {
                if (new EstudiantesBN().Guardar(modelo, ref error))
                    return Json(new { estado = true });

                ModelState.AddModelError("GradoId", error);
            }

            return EnviarErrores(ModelState);
        }

        [HttpPost]
        public JsonResult ActualizarEstudiante(EstudiantesDTO modelo)
        {
            if (ModelState.IsValid)
            {
                if (new EstudiantesBN().Editar(modelo, ref error))
                    return Json(new { estado = true });

                ModelState.AddModelError("GradoId", error); 
            }

            return EnviarErrores(ModelState);
        }

        [HttpPost]
        public JsonResult EliminarEstudiante(int estudianteId)
        {
            if (new EstudiantesBN().Eliminar(estudianteId, ref error))
                return Json(new { estado = true });

            return Json(new { estado = false, error});
        }

        private JsonResult EnviarErrores(ModelStateDictionary modelState)
        {
            return Json(new
            {
                estado = false,
                formErrors = modelState.Select(kvp => new
                {
                    key = kvp.Key,
                    errors = kvp.Value.Errors.Select(e => e.ErrorMessage)
                })
            });
        }
    }
}