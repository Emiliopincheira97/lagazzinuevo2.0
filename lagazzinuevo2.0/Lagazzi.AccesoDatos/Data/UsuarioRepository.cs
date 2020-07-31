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
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepository
    {
        
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void BloqueaUsuario(string IdUsuario)
        {
            var usuarioDesdeDb = _db.ApplicatonUser.FirstOrDefault(u => u.Id == IdUsuario);
            usuarioDesdeDb.LockoutEnd = DateTime.Now.AddYears(100);
            _db.SaveChanges();
        }

        public void DesbloqueaUsuario(string IdUsuario)
        {
            var usuarioDesdeDb = _db.ApplicatonUser.FirstOrDefault(u => u.Id == IdUsuario);
            usuarioDesdeDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
