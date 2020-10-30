using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;

namespace MVC_TicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var value = c.Caris.Where(x => x.Durum == true).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariEkle");
            }
            c.Caris.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Caris.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cari newCari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var value = c.Caris.Find(newCari.CariID);
            value.CariAd = newCari.CariAd;
            value.CariSoyad = newCari.CariSoyad;
            value.CariSehir = newCari.CariSehir;
            value.CariMail = newCari.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var value = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cariName = c.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cN = cariName;
            return View(value);
        }
    }
}