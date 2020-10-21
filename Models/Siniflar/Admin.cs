using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVC_TicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        //KullanıcıAdı Kısmı
        [Column(TypeName = "VARCHAR")]
        [StringLength(10, ErrorMessage = "En fazla 10 karakterden oluşan bir kullanıcı adı giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string KullaniciAd { get; set; }
        //Şifre Kısmı
        [Column(TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakterden oluşan bir şifre giriniz.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        [MembershipPassword(
            MinRequiredNonAlphanumericCharacters = 1,
            MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
            ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
            MinRequiredPasswordLength = 6
        )]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        [Column(TypeName = "CHAR")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}