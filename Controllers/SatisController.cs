using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;

namespace MVC_TicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var value = c.SatisHarekets.ToList();
            return View(value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> val1 = (from x in c.Urunlers.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.UrunAd,
                                            Value = x.UrunID.ToString()
                                        }).ToList();
            List<SelectListItem> val2 = (from x in c.Caris.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CariAd + " " + x.CariSoyad,
                                            Value = x.CariID.ToString()
                                        }).ToList();
            List<SelectListItem> val3 = (from x in c.Personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd + " " + x.PersonelSoyad,
                                             Value = x.PersonelID.ToString()
                                         }).ToList();

            ViewBag.value1 = val1;
            ViewBag.value2 = val2;
            ViewBag.value3 = val3;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satis)
        {
            if (!ModelState.IsValid)
            {
                return View("SatisEkle");
            }
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> val1 = (from x in c.Urunlers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            List<SelectListItem> val2 = (from x in c.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            List<SelectListItem> val3 = (from x in c.Personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd + " " + x.PersonelSoyad,
                                             Value = x.PersonelID.ToString()
                                         }).ToList();

            ViewBag.value1 = val1;
            ViewBag.value2 = val2;
            ViewBag.value3 = val3;
            var value = c.SatisHarekets.Find(id);
            return View("SatisGetir", value);
        }
        [Authorize]
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var value = c.SatisHarekets.Find(s.SatisID);
            value.CariID = s.CariID;
            value.Adet = s.Adet;
            value.Fiyat = s.Fiyat;
            value.PersonelID = s.PersonelID;
            value.Tarih = s.Tarih;
            value.ToplamTutar = s.ToplamTutar;
            value.UrunID = s.UrunID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult SatisDetay(int id)
        {
            var values = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(values);
        }
    }
}