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
    public class TipoTrabajadorRepository : Repository<TipoTrabajador>, ITipoTrabajadorRepository
    {

        private readonly ApplicationDbContext _db;

        public TipoTrabajadorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaTipoTrabajador()
        {
            return _db.TipoVehiculo.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(TipoTrabajador tipoTrabajador)
        {
            var objDesdeDb = _db.TipoTrabajador.FirstOrDefault(s => s.Id == tipoTrabajador.Id);
            objDesdeDb.Nombre = tipoTrabajador.Nombre;
            _db.SaveChanges();
        }
    }
}
