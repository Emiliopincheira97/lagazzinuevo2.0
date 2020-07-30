using Lagazzi.AccesoDatos.Data.Repository;
using Lagazzi.Models;
using lagazzinuevo2._0.AccesoDatos.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lagazzi.AccesoDatos.Data
{
    public class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
    {

        private readonly ApplicationDbContext _db;

        public VehiculoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetVehiculo()
        {
            return _db.Vehiculo.Select(i => new SelectListItem()
            {
                Text = i.Marca,
                Value = i.Id.ToString()
            });
        }

        public void Update(Vehiculo vehiculo)
        {
            var objDesdeDb = _db.Vehiculo.FirstOrDefault(s => s.Id == vehiculo.Id);
            objDesdeDb.Marca = vehiculo.Marca;
            objDesdeDb.Modelo = vehiculo.Modelo;
            objDesdeDb.Patente = vehiculo.Patente;
            objDesdeDb.Anio = vehiculo.Anio;
            objDesdeDb.TipoVehiculoId = vehiculo.TipoVehiculoId;
            
            //_db.SaveChanges();
        }
    }
}
