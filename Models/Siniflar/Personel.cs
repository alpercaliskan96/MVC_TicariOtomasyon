using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [DisplayName("Personel Adı")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakterden oluşan bir isim giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string PersonelAd { get; set; }
        [Column(TypeName = "VARCHAR")]
        [DisplayName("Personel Soyadı")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakterden oluşan bir isim giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [DisplayName("Personel Görsel")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }

    }
}