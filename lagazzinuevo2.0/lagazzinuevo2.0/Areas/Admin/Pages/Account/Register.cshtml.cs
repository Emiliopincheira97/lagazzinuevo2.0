using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lagazzinuevo2._0.Areas.Admin.Views.Usuarios.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<IdentityUser> _userManager;
        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;

        }

        public string Message { get; set; }

        public void OnGet(string data)
        {
            Message = data;
        }
        public InputModel Input { get; set; }


        public class InputModel
        {



            public string Run { get; set; }
            [Required]
            [EmailAddress(ErrorMessage = "Correo inválido")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Nombre no puede ir vacío")]
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }


            [Required(ErrorMessage = "Apellido no puede ir vacío")]
            [Display(Name = "Apellido")]
            public string Apellido { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Apellido no puede ir vacío")]
            [StringLength(100, ErrorMessage ="El número de caracteres de {0} debe ser al menos de {2}",MinimumLength =6)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [Compare("Password",ErrorMessage ="Las contraseñas no coindicen")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Contraseña no puede ir vacía")]
            [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos de {2}", MinimumLength = 6)]
            [Display(Name = "Confirmar Contraseña")]
            public string ConfirmPassword { get; set; }

       
            public string ErrorMessage { get; set; }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userList = _userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList();
                if (userList.Count.Equals(0))
                {
                    var user = new IdentityUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email,

                    };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                      
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {

                            Input = new InputModel
                            {
                                ErrorMessage = $"El  {item.Description} ya está registrado",
                            };
                        }
                        return Page();
                    }
                }
                else
                {
                    Input = new InputModel
                    {
                        ErrorMessage = "El " + Input.Email + " ya está registrado",
                    };
                }
                return Page();
            }
        }

    }
}
