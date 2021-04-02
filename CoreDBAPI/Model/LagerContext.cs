using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDBAPI.Model;

namespace CoreDBAPI.Model
{
    public class LagerContext : DbContext
    {

        public DbSet<Artiklar> Artiklars { get; set; }

        public LagerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CoreDBAPI.Model.Kategori> Kategori { get; set; }
    }
}
