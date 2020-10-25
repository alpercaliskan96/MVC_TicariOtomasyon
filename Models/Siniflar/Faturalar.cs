using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Fatura Seri Numarası")]
        [Column(TypeName = "CHAR")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [DisplayName("Fatura Sıra Numarası")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [DisplayName("Vergi Dairesi")]
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        [DisplayName("Teslim Eden Kişi")]
        public string TeslimEden { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        [DisplayName("Teslim Alan Kişi")]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}