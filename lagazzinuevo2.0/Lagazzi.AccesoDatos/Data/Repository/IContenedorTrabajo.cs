using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ITipoVehiculoRepository TipoVehiculo { get; }
        IVehiculoRepository Vehiculo { get; }

        void Save(); 
    }
}
