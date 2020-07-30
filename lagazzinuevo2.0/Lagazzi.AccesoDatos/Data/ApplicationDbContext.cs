using System;
using System.Collections.Generic;
using System.Text;
using Lagazzi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lagazzinuevo2._0.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
    }
}
