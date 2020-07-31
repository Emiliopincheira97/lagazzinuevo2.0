using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagazzi.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace lagazzinuevo2._0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrabajadoresController : Controller{

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public TrabajadoresController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
    
        public IActionResult Index()
        {
            return View();
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Trabajador.GetAll(includeProperties: "TipoTrabajador,Estado") });

        }

        [HttpDelete]
        public IActionResult BorrarTrabajador(int id)
        {

            var objFromDb = _contenedorTrabajo.Trabajador.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando vehiculo" });

            }

            _contenedorTrabajo.Trabajador.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado Correctamente" });

        }

        #endregion
    }
}
