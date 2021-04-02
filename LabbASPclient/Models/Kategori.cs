using LabbASPclient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbASPclient.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string Kategorinamn { get; set; }

        public List<Artiklar> Artiklars { get; set; }

    }
}
