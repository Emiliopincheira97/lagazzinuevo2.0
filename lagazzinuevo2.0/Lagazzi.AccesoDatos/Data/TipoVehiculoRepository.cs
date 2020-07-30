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
    public class TipoVehiculoRepository : Repository<TipoVehiculo>, ITipoVehiculoRepository
    {

        private readonly ApplicationDbContext _db;

        public TipoVehiculoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaTipoVehiculo()
        {
            return _db.TipoVehiculo.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(TipoVehiculo tipoVehiculo)
        {
            var objDesdeDb = _db.TipoVehiculo.FirstOrDefault(s => s.Id == tipoVehiculo.Id);
            objDesdeDb.Nombre = tipoVehiculo.Nombre;
            _db.SaveChanges();
        }
    }
}
