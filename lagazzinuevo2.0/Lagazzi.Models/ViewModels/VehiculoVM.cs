using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lagazzi.Models.ViewModels
{
    public class VehiculoVM
    {
        public Vehiculo Vehiculo { get; set; }

       
        public IEnumerable<SelectListItem> ListaTipoVehiculo { get; set; }
    }
}
