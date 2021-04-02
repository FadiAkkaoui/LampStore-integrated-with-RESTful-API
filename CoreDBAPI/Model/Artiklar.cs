using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDBAPI.Model
{
    public class Artiklar
    {
        public int Id { get; set; }
        public string Produktnamn { get; set; }
        public string Produktbeskrivning { get; set; }
        public int Pris { get; set; }
        public int Antal { get; set; }
        public string Tillverkare { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
