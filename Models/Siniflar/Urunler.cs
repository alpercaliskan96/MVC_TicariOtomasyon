using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName ="VARCHAR")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public Kategori Kategori { get; set; }
        public SatisHareket SatisHareket { get; set; }
    }
}