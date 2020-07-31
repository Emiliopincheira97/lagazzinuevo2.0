using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagazzi.AccesoDatos.Data.Repository;
using Lagazzi.Models.ViewModels;
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



        [HttpGet]
        public IActionResult CreateTrabajador()
        {
            TrabajadorVM trabajadorvm = new TrabajadorVM()
            {
                Trabajador = new Lagazzi.Models.Trabajador(),
                ListaTipoTrabajador = _contenedorTrabajo.TipoTrabajador.GetListaTipoTrabajador(),
                ListaEstado = _contenedorTrabajo.Estado.GetListaEstado()
            };
            return View(trabajadorvm);
        }

        [HttpGet]
        public IActionResult EditarTrabajador(int? id)
        {
            TrabajadorVM trabajadorvm = new TrabajadorVM()
            {
                Trabajador = new Lagazzi.Models.Trabajador(),
                ListaTipoTrabajador = _contenedorTrabajo.TipoTrabajador.GetListaTipoTrabajador(),
                ListaEstado = _contenedorTrabajo.Estado.GetListaEstado()
            };

            if (id != null)
            {
                trabajadorvm.Trabajador = _contenedorTrabajo.Trabajador.Get(id.GetValueOrDefault());
            }

            return View(trabajadorvm);

        }


        #region LLAMADAS A LA API

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarTrabajador(TrabajadorVM trabajadorvm)
        {

            var trabajadorDesdeDb = _contenedorTrabajo.Trabajador.Get(trabajadorvm.Trabajador.Id);
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Trabajador.Update(trabajadorvm.Trabajador);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));


            }
            return View();

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Trabajador.GetAll(includeProperties: "TipoTrabajador,Estado") });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTrabajador(TrabajadorVM trabajadorvm)
        {
            if (ModelState.IsValid)
            {
                if (trabajadorvm.Trabajador.Id == 0)
                {

                    _contenedorTrabajo.Trabajador.Add(trabajadorvm.Trabajador);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));

                }
            }
            return View();

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
