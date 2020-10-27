using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;

namespace MVC_TicariOtomasyon.Controllers
{
    public class TabloController : Controller
    {
        Context c = new Context();
        // GET: Tablo
        public ActionResult Index()
        {
            var val1 = c.Caris.Count().ToString();
            ViewBag.val1 = val1;

            var val2 = c.Urunlers.Count().ToString();
            ViewBag.val2 = val2;

            var val3 = c.Personels.Count().ToString();
            ViewBag.val3 = val3;

            var val4 = c.Kategoris.Count().ToString();
            ViewBag.val4 = val4;

            var val5 = c.Urunlers.Sum(x => x.Stok).ToString();
            ViewBag.val5 = val5;

            var val6 = (from x in c.Urunlers select x.Marka).Distinct().Count().ToString();
            ViewBag.val6 = val6;

            var val7 = c.Urunlers.Count(x => x.Stok <= 10).ToString();
            ViewBag.val7 = val7;

            var val8 = (from x in c.Urunlers orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.val8 = val8;

            var val9 = (from x in c.Urunlers orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.val9 = val9;

            var val10 = c.Urunlers.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.val10 = val10;

            var val11 = c.Urunlers.Where(u => u.UrunID == 
            (c.SatisHarekets.GroupBy(x => x.UrunID)
            .OrderByDescending(y => y.Count())
            .Select(z => z.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.val11 = val11;

            var val12 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.val12 = val12;

            DateTime bugun = DateTime.Today;
            var value13 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.val13 = value13;

            var value14 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
            ViewBag.val14 = value14;
            return View();
        }
        
        public ActionResult BasicTable()
        {
            var value = from x in c.Caris
                        group x by x.CariSehir into g
                        select new MiniTablo
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(value);
        }
    }
}