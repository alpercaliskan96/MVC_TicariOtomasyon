using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;
namespace MVC_TicariOtomasyon.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Caris.Count().ToString();
            ViewBag.value1 = value1;
            var value2 = c.Urunlers.Count().ToString();
            ViewBag.value2 = value2;
            var value3 = c.Kategoris.Count().ToString();
            ViewBag.value3 = value3;
            var value4 = c.Personels.Count().ToString();
            ViewBag.value4 = value4;

            var toDo = c.YapilacakListesis.ToList();
            return View(toDo);
        }
    }
}