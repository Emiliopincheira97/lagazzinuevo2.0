using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lagazzi.Models
{
    public class TipoVehiculo
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage= "Ingresa un nombre para el tipo de vehículo")]
        [Display(Name ="Nombre Tipo Vehículo:")]
        public string Nombre { get; set; }
    }
}
