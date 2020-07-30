using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagazzi.AccesoDatos.Data.Repository;
using Lagazzi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace lagazzinuevo2._0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehiculosController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public VehiculosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

       
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult CreateVehiculo()
        {
            VehiculoVM vehiculovm = new VehiculoVM()
            {
                Vehiculo = new Lagazzi.Models.Vehiculo(),
                ListaTipoVehiculo = _contenedorTrabajo.TipoVehiculo.GetListaTipoVehiculo()
            };
            return View(vehiculovm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateVehiculo(VehiculoVM vehiculovm)
        {
            if (ModelState.IsValid)
            {
                if (vehiculovm.Vehiculo.Id == 0)
                {

                    _contenedorTrabajo.Vehiculo.Add(vehiculovm.Vehiculo);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));

                }
            }
            return View();

        }

        [HttpGet]
        public IActionResult EditarVehiculo(int? id)
        {
            VehiculoVM vehiculovm = new VehiculoVM()
            {
                Vehiculo = new Lagazzi.Models.Vehiculo(),
                ListaTipoVehiculo = _contenedorTrabajo.TipoVehiculo.GetListaTipoVehiculo()
            };

            if (id != null)
            {
                vehiculovm.Vehiculo = _contenedorTrabajo.Vehiculo.Get(id.GetValueOrDefault());
            }

            return View(vehiculovm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarVehiculo(VehiculoVM vehiculovm)
        {

            var vehiculoDesdeDb = _contenedorTrabajo.Vehiculo.Get(vehiculovm.Vehiculo.Id);
            if (ModelState.IsValid)
            {
               

                    _contenedorTrabajo.Vehiculo.Update(vehiculovm.Vehiculo);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));

                
            }
            return View();

        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Vehiculo.GetAll(includeProperties:"TipoVehiculo") });

        }

        [HttpDelete]
        public IActionResult BorrarVehiculo(int id)
        {

            var objFromDb = _contenedorTrabajo.Vehiculo.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando vehiculo" });

            }

            _contenedorTrabajo.Vehiculo.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado Correctamente" });

        }

        #endregion

    }
}
