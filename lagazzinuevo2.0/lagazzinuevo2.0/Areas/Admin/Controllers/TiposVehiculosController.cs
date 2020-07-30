using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagazzi.AccesoDatos.Data.Repository;
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



        public IActionResult Index()
        {
            return View();
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.TipoVehiculo.GetAll()});

        }

        #endregion

    }
}
