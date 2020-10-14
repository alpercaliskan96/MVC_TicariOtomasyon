using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urunler> Urunlers  { get; set; }
    }
}