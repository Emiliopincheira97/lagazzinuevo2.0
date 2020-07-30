using Lagazzi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.AccesoDatos.Data.Repository
{
    public interface IVehiculoRepository : IRepository<Vehiculo>
    {
      



        void Update(Vehiculo vehiculo);

    }
}
