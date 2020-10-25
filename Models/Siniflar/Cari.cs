using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }
        [DisplayName("Cari Adı")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakterden oluşan bir isim giriniz.")]
        [Required(ErrorMessage ="Bu alanı boş bırakamazsınız.")]
        public string CariAd { get; set; }
        [DisplayName("Cari Soyadı")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakterden oluşan bir soyadı giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string CariSoyad { get; set; }
        [DisplayName("Şehir")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(13,ErrorMessage = "En fazla 13 karakterden oluşan bir şehir ismi giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string CariSehir { get; set; }
        [DisplayName("Mail Adresi")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        [EmailAddress(ErrorMessage = "Geçersiz email adresi")]
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}