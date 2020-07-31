using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.Models.ViewModels
{
    public class TrabajadorVM
    {

        public Trabajador Trabajador { get; set; }


        public IEnumerable<SelectListItem> ListaTipoTrabajador { get; set; }
        public IEnumerable<SelectListItem> ListaEstado { get; set; }
    }
}
