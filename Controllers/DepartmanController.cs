﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;

namespace MVC_TicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var value = c.Departmans.Where(x=>x.Durum == true).ToList();
            return View(value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult DepartmanEkle(Departman dep)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanEkle");
            }
            c.Departmans.Add(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DepartmanGetir(int id)
        {     
            var dep = c.Departmans.Find(id);
            return View("DepartmanGetir", dep);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanGetir");
            }
            var dep = c.Departmans.Find(d.DepartmanID);
            dep.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DepartmanDetay(int id)
        {
            var value = c.Personels.Where(x => x.PersonelID == id).ToList();
            var depName = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dN = depName;
            return View(value);
        }
        [Authorize]
        public ActionResult PersonelSatisDetay(int id)
        {
            var value = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var perName = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.pN = perName;
            return View(value);
        }
    }
}