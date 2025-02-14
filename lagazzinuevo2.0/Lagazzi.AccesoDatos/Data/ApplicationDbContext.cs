﻿using System;
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
        public DbSet<Estado> Estado { get; set; }
        public DbSet<TipoTrabajador> TipoTrabajador { get; set; }
        public DbSet<Vehiculo> Vehiculo{ get; set; }
        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public DbSet<Trabajador> Trabajador { get; set; }
        public DbSet<ApplicationUser> ApplicatonUser { get; set; }
    }
}

