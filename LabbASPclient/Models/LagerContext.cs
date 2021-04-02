using LabbASPclient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbASPclient.Models
{
    public class LagerContext : DbContext
    {
        public DbSet<Artiklar> Artiklars { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }

        //public LagerContext()
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { 
            options.UseSqlite("Data Source=artiklars.db");
        }
    }
}
