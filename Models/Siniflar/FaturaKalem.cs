using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }
        [DisplayName("Açıklama Kısmı")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100,ErrorMessage = "En fazla 30 karakterden oluşan bir isim giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public int Miktar { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        [DisplayName("Birim Fiyatı")]
        public decimal BirimFiyat { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public decimal Tutar { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public Faturalar Faturalar { get; set; }
    }
}