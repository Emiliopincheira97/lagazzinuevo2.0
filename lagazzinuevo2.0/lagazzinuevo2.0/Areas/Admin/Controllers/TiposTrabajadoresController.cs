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

        [HttpGet]
        public IActionResult CreateTipoTrabajador()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditarTipoTrabajador(int id)
        {
            TipoTrabajador tipoTrabajador = new TipoTrabajador();
            tipoTrabajador = _contenedorTrabajo.TipoTrabajador.Get(id);
            if (tipoTrabajador == null)
            {
                return NotFound();
            }
            return View(tipoTrabajador);
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.TipoTrabajador.GetAll() });

        }

        [HttpDelete]
        public IActionResult BorrarTipoTrabajador(int id)
        {

            var objFromDb = _contenedorTrabajo.TipoTrabajador.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo vehiculo" });

            }

            _contenedorTrabajo.TipoTrabajador.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado Correctamente" });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTipoTrabajador(TipoTrabajador tipotrabajador)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.TipoTrabajador.Add(tipotrabajador);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipotrabajador);
        }
        [HttpPost]
        public IActionResult EditarTipoTrabajador(TipoTrabajador tipoTrabajador)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.TipoTrabajador.Update(tipoTrabajador);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTrabajador);
        }
     

        #endregion
    }



}
