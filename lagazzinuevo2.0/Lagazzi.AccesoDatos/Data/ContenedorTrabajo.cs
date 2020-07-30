using Lagazzi.AccesoDatos.Data.Repository;
using lagazzinuevo2._0.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagazzi.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {


        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            TipoVehiculo = new TipoVehiculoRepository(_db);
        }
        public ITipoVehiculoRepository TipoVehiculo { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
