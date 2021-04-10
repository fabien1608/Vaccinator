using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vaccinator.Models;

namespace Vaccinator.Models
{
    public class ContexteBDD: DbContext
    {
        public DbSet<Personne> Personnes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data source = vaccins.db");
        }

        public DbSet<Vaccinator.Models.Vaccin> Vaccin { get; set; }
    }
}
