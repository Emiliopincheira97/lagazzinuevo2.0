using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagazzi.AccesoDatos.Data.Repository;
using Lagazzi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            VehiculoVM vehiculovm = new VehiculoVM()
            {
                Vehiculo = new Lagazzi.Models.Vehiculo(),
                ListaTipoVehiculo = _contenedorTrabajo.TipoVehiculo.GetListaTipoVehiculo()
            };
            return View(vehiculovm);
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Vehiculo.GetAll(includeProperties:"TipoVehiculo") });

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
