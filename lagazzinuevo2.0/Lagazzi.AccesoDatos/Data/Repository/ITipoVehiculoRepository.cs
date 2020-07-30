using Lagazzi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.AccesoDatos.Data.Repository
{
    public interface ITipoVehiculoRepository : IRepository<TipoVehiculo>
    {
        IEnumerable<SelectListItem> GetListaTipoVehiculo();



        void Update(TipoVehiculo tipoVehiculo);


    }
}
