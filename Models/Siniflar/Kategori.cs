﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Kategori Adı")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakterden oluşan bir isim giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string KategoriAd { get; set; }
        public ICollection<Urunler> Urunlers  { get; set; }
    }
}