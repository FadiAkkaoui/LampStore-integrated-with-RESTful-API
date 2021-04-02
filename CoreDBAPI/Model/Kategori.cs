using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDBAPI.Model
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string Kategorinamn { get; set; }

        public List<Artiklar> Artiklars { get; set; }

    }
}
