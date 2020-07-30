using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lagazzi.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage ="Ingresar Marca por favor")]
        [Display(Name ="Marca")]
        public string Marca { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "Ingresar Patente por favor")]
        [Display(Name = "Patente")]
        public string Patente { get; set; }


        [Required(ErrorMessage = "Ingresar Año por favor")]
        [Display(Name = "Año")]
        public int Anio { get; set; }


        [Required]
        public int TipoVehiculoId  { get; set; }

        [ForeignKey("TipoVehiculoId")]
        public TipoVehiculo TipoVehiculo { get; set; }

    }
}
