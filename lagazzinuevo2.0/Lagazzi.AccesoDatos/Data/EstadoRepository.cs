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
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {

        private readonly ApplicationDbContext _db;

        public EstadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaEstado()
        {
            return _db.Estado.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Estado estado)
        {
            var objDesdeDb = _db.Estado.FirstOrDefault(s => s.Id == estado.Id);
            objDesdeDb.Nombre = estado.Nombre;
            _db.SaveChanges();
        }
    }
}
