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
        [StringLength(30, ErrorMessage = "En fazla 30 karakterden oluşan bir ürün ismi giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string UrunAd { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakterden oluşan bir marka ismi giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public short Stok { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public decimal AlisFiyati { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public decimal SatisFiyati { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public bool Durum { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string UrunGorsel { get; set; }
        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}