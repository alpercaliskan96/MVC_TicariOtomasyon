using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class YapilacakListesi
    {
        [Key]
        public int YapilacakID { get; set; }
        [DisplayName("Açıklama")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakterden oluşan bir açıklama giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string Aciklama { get; set; }

        [Column(TypeName = "bit")]
        [DisplayName("Durum")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public bool Durum { get; set; }
        
    }
}