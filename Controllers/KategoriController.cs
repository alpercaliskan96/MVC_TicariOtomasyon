using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;

namespace MVC_TicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Kategoris.ToList();
            return View(value);
        }
    }
}