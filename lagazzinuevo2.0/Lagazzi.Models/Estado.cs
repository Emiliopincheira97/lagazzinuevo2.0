using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lagazzi.Models
{
   public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Ingresa un nombre para el Estado")]
        [Display(Name = "Nombre Estado:")]
        public string Nombre { get; set; }
    }
}
