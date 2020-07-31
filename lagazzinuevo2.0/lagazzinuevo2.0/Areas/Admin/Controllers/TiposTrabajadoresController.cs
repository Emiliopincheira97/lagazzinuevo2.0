using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagazzi.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace lagazzinuevo2._0.Areas.Admin.Controllers
{   

    [Area("Admin")]
    public class TiposTrabajadoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public TiposTrabajadoresController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo; //podemos ingresar a todas las entidades
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.TipoTrabajador.GetAll() });

        }

        [HttpDelete]
        public IActionResult BorrarTipoVehiculo(int id)
        {

            var objFromDb = _contenedorTrabajo.TipoVehiculo.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo vehiculo" });

            }

            _contenedorTrabajo.TipoVehiculo.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado Correctamente" });

        }

        #endregion
    }



}
