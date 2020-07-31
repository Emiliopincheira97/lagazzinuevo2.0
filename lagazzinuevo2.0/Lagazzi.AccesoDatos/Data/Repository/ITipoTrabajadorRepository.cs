using Lagazzi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.AccesoDatos.Data.Repository
{
    public interface ITipoTrabajadorRepository : IRepository<TipoTrabajador>
    {
        IEnumerable<SelectListItem> GetListaTipoTrabajador();



        void Update(TipoTrabajador tipoTrabajador);


    }
}
