using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbASPclient.Models
{
    public class ArtikelAPI
    {
        public int Id { get; set; }
        public string Produktnamn { get; set; }
        public string Produktbeskrivning { get; set; }
        public int Pris { get; set; }
        public int Antal { get; set; }
        public string Tillverkare { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategorinamn { get; set; }
    }
}
