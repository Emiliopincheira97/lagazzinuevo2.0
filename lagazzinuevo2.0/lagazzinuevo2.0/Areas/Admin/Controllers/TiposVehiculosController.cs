using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagazzi.AccesoDatos.Data.Repository;
using Lagazzi.Models;
using Microsoft.AspNetCore.Mvc;

namespace lagazzinuevo2._0.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class TiposVehiculosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public TiposVehiculosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo; //podemos ingresar a todas las entidades
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTipoVehiculo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.TipoVehiculo.Add(tipoVehiculo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoVehiculo);
        }


        [HttpGet]
        public IActionResult EditarTipoVehiculo(int id)
        {
            TipoVehiculo tipoVehiculo = new TipoVehiculo();
            tipoVehiculo = _contenedorTrabajo.TipoVehiculo.Get(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }
            return View(tipoVehiculo);
        }

        [HttpPost]
        public IActionResult EditarTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.TipoVehiculo.Update(tipoVehiculo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoVehiculo);
        }




        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.TipoVehiculo.GetAll()});

        }

        [HttpDelete]
        public IActionResult BorrarTipoVehiculo(int id) {

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
