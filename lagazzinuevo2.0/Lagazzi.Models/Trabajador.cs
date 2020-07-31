using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lagazzi.Models
{
    public class Trabajador
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(13)")]
        [Required(ErrorMessage = "Ingresa run para el trabajador")]
        [Display(Name = "Run")]
        public string Run { get; set; }

        [Column(TypeName = "varchar(45)")]
        [Required(ErrorMessage = "Ingresa un nombre para el trabajador")]
        [Display(Name = "Nombre")]
        public string Nombres { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Ingresa un Apellido para el trabajador")]
        [Display(Name = "Apellido")]
        public string Apellidos { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Required(ErrorMessage = "Ingresa un correo para el trabajador")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Tipo de trabajador no seleccionado")]
        [Display(Name = "Tipo de trabajador")]
        public int TipoTrabajadorId { get; set; }

        [Required(ErrorMessage = "Estado no seleccionado")]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }

        [ForeignKey("TipoTrabajadorId")]
        public TipoTrabajador TipoTrabajador { get; set; }
    }
}
