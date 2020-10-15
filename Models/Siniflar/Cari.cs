﻿using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
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

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string CariAd { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}