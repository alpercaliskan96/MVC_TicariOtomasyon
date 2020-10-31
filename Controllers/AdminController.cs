using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_TicariOtomasyon.Models.Siniflar;
using System.Web.Security;

namespace MVC_TicariOtomasyon.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin
        public ActionResult Index()
        {
            var value = c.Admins.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult YeniKullanici()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKullanici(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKullanici");
            }
            c.Admins.Add(admin);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       

        [HttpGet]
        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SifremiUnuttum(string KullaniciAd)
        {
            var sorgu = (from x in c.Admins where x.KullaniciAd.Equals(KullaniciAd) select x).SingleOrDefault(); // !üyeyi yakaladık

            if (sorgu != null) // !üye varsa kod yolladık 
            {
                Guid randomkey = Guid.NewGuid(); // !32 karakterli kodu ürettik

                sorgu.Sifirlama = randomkey.ToString().Substring(0, 5); // !/keyi ekleyip veritabanına ekledik

                c.SaveChanges(); // ! kaydettik

                SmtpClient client = new SmtpClient("mail.server.com");
                MailAddress from = new MailAddress("info@server.com");
                MailAddress to = new MailAddress(sorgu.KullaniciAd);// !userin mailini yazdık
                MailMessage msg = new MailMessage(from, to);
                msg.IsBodyHtml = true;
                msg.Subject = "Şifre Degiştirme İsteği Bildirimi";
                msg.Body += "<h2>  Merhaba " + sorgu.KullaniciAd + " Şifre Degiştirme İsteğiniz Alınmıştır.  Kodunuz" + randomkey.ToString().Substring(0, 5) + "  Sitemize girerek şifrenizi Güncelleyiniz </h2>  </br>  "; // !randomkeyimizi 8 karatere düşdük
                NetworkCredential info = new NetworkCredential("info@server.com", "sifreniz");
                client.Credentials = info;
                client.Send(msg); ///gönderdik

            }

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Admin a)
        {
            var value = c.Admins.FirstOrDefault(x => x.KullaniciAd == a.KullaniciAd && x.Sifre == a.Sifre);

            if( value != null)
            {
                FormsAuthentication.SetAuthCookie(value.KullaniciAd, false);
                Session["KullaniciAd"] = value.KullaniciAd.ToString();
                return RedirectToAction("Index","Anasayfa");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }


    }
}