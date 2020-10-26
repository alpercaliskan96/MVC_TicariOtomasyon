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
        [StringLength(1, ErrorMessage = "En fazla 1 karakterden oluşan bir Fatura Seri numarası giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string FaturaSeriNo { get; set; }
        [DisplayName("Fatura Sıra Numarası")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(6, ErrorMessage = "En fazla 6 karakterden oluşan bir Fatura Sıra numarası giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string FaturaSiraNo { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public DateTime Tarih { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakterden oluşan bir Vergi Dairesi ismi giriniz.")]
        [DisplayName("Vergi Dairesi")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "CHAR")]
        [StringLength(5, ErrorMessage = "En fazla 5 karakterden oluşan bir Saat giriniz.")]
        [DisplayName("Saat")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public String Saat { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "En fazla 50 karakterden oluşan bir Teslim Eden Kişi ismi giriniz.")]
        [DisplayName("Teslim Eden Kişi")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string TeslimEden { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "En fazla 50 karakterden oluşan bir Teslim Alan Kişi ismi giriniz.")]
        [DisplayName("Teslim Alan Kişi")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}