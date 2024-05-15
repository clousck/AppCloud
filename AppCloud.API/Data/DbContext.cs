using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppCloud.Entidades;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<AppCloud.Entidades.Game> Games { get; set; } = default!;

        public DbSet<AppCloud.Entidades.Launcher> Launchers { get; set; } = default!;
    }
