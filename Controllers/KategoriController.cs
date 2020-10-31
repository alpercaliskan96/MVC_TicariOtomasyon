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
        [Authorize]
        public ActionResult Index()
        {
            var value = c.Kategoris.ToList();
            return View(value);
        }
        //GET 
        [Authorize]
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [Authorize]
        //POST KISMI
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        //KATEGORI SILME ISLEMI
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        //KATEGORI GETIRME ISLEMI
        public ActionResult KategoriDuzenle(int id)
        {
            var ktg = c.Kategoris.Find(id);
            return View("KategoriDuzenle", ktg);
        }
        [Authorize]
        //KATEGORI GUNCELLEME ISLEMI
        public ActionResult KategoriGuncelle(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriDuzenle");
            }
            var ktg = c.Kategoris.Find(k.KategoriID);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}