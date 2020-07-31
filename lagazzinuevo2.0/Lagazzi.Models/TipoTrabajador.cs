using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lagazzi.Models
{
    public class TipoTrabajador
    {

        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Ingresa un nombre para el tipo de trabajador")]
        [Display(Name = "Nombre Tipo Trabajador:")]
        public string Nombre { get; set; }

    }
}
