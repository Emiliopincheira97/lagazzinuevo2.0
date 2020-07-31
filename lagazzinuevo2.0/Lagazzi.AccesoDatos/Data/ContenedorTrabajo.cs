using Lagazzi.AccesoDatos.Data.Repository;
using Lagazzi.Models;
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
            Vehiculo = new VehiculoRepository(_db);
            Trabajador = new TrabajadorRepository(_db);
            Estado = new EstadoRepository(_db);
            TipoTrabajador = new TipoTrabajadorRepository(_db);
            Usuario = new UsuarioRepository(_db);
        }
        public ITipoVehiculoRepository TipoVehiculo { get; private set; }
        public IVehiculoRepository Vehiculo { get; private set; }

        public IEstadoRepository Estado { get; private set; }

        public ITrabajadorRepository Trabajador { get; private set; }

        public ITipoTrabajadorRepository TipoTrabajador { get; private set; }

        public IUsuarioRepository Usuario { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
