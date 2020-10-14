using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        //ürün - cari - personel gelecek
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public ICollection<Urunler> Urunlers { get; set; }
        public ICollection<Cari> Caris { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}