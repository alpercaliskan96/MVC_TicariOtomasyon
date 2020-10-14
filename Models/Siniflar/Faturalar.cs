using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "CHAR")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}