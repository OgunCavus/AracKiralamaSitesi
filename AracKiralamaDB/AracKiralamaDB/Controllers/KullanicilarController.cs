using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AracKiralamaDB.Models;

namespace AracKiralamaDB.Controllers
{
    public class KullanicilarController : Controller
    {
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();
        // GET: Kullanicilar
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar k)
        {
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
            if (kullanici !=null) {
                if (kullanici.Kullanıcı_Tipi == "Admin")
                {
                    FormsAuthentication.SetAuthCookie(k.KullaniciAdi, false);
                    return RedirectToAction("Index", "Home");
                }
                else if (kullanici.Kullanıcı_Tipi == "Musteri")
                {
                    return RedirectToAction("MusteriAnaSayfa", "AnaSayfa");
                }
            }
            ViewBag.hata = "Kullanıcı adı veya şifre yanlış";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}