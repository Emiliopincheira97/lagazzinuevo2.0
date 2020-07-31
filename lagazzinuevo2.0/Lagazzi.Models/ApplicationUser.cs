using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lagazzi.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required(ErrorMessage = "El run es obligatorio")]
        public string Run { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string  Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        public string Apellidos { get; set; }


    }
}
