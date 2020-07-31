using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.Models.ViewModels
{
    class TrabajadorVM
    {

        public Vehiculo Vehiculo { get; set; }


        public IEnumerable<SelectListItem> ListaTipoVehiculo { get; set; }
        public IEnumerable<SelectListItem> ListaEstado { get; set; }
    }
}
