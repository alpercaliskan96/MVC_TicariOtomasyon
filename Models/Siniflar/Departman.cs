using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakterden oluşan bir departman ismi giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }

    }
}