using Lagazzi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.AccesoDatos.Data.Repository
{
    public interface IUsuarioRepository : IRepository<ApplicationUser>
    {

        void BloqueaUsuario(string IdUsuario);

        void DesbloqueaUsuario(string IdUsuario);


    }
}
