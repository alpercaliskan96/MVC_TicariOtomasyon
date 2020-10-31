using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;

namespace MVC_TicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var urunler = c.Urunlers.Where(x => x.Durum==true).ToList();
            return View(urunler);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> newVal = (from x in c.Kategoris.ToList()
                                           select new SelectListItem { 
                                               Text = x.KategoriAd, Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.val = newVal;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniUrun(Urunler urun)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniUrun");
            }
            c.Urunlers.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult UrunSil(int id)
        {
            var urun = c.Urunlers.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }
        [Authorize]
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> newVal = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.val2 = newVal;

            var newKategori = c.Kategoris.ToList();
            ViewBag.KategoriList = new SelectList(newKategori, "KategoriID", "KategoriAd");

           // ! Testing
            var urun = c.Urunlers.Find(id);
            return View("UrunGetir", urun);
        }
        [Authorize]
        public ActionResult UrunGuncelle(Urunler u)
        {
            if (!ModelState.IsValid)
            {
                return View("UrunGetir");
            }
            var urun = c.Urunlers.Find(u.UrunID);
            urun.UrunAd= u.UrunAd;
            urun.Marka= u.Marka;
            urun.Stok= u.Stok;
            urun.AlisFiyati= u.AlisFiyati;
            urun.SatisFiyati= u.SatisFiyati;
            urun.KategoriID = u.KategoriID;
            urun.UrunGorsel = u.UrunGorsel;
            urun.Durum= u.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult UrunListesi()
        {
            var value = c.Urunlers.ToList();
            return View(value);
        }
    }
}