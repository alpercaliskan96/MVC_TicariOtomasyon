using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;

namespace MVC_TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var value = c.Faturalars.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            if (!ModelState.IsValid)
            {
                return View("FaturaEkle");
            }
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            if (!ModelState.IsValid)
            {
                return View("FaturaGetir");
            }
            var value = c.Faturalars.Find(f.FaturaID);
            value.FaturaSeriNo = f.FaturaSeriNo;
            value.FaturaSiraNo = f.FaturaSiraNo;
            value.VergiDairesi = f.VergiDairesi;
            value.Tarih = f.Tarih;
            value.Saat = f.Saat;
            value.TeslimEden = f.TeslimEden;
            value.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var value = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}