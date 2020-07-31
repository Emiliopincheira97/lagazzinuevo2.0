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
    public class TrabajadorRepository : Repository<Trabajador>, ITrabajadorRepository
    {

        private readonly ApplicationDbContext _db;

        public TrabajadorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Trabajador trabajador)
        {
            var objDesdeDb = _db.Trabajador.FirstOrDefault(s => s.Id == trabajador.Id);
            objDesdeDb.Run = trabajador.Run;
            objDesdeDb.Nombres = trabajador.Nombres;
            objDesdeDb.Apellidos = trabajador.Apellidos;
            objDesdeDb.Correo = trabajador.Correo;
            objDesdeDb.TipoTrabajadorId = trabajador.TipoTrabajadorId;
            objDesdeDb.EstadoId = trabajador.EstadoId;

            //_db.SaveChanges();
        }
    }
}
