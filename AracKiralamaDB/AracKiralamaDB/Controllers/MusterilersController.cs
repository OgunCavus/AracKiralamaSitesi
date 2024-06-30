using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AracKiralamaDB.Models;

namespace AracKiralamaDB.Controllers
{
    public class MusterilersController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: Musterilers
        public ActionResult Index()
        {
            var musteriler = db.Musteriler.Include(m => m.Cinsiyetler);
            return View(musteriler.ToList());
        }

        // GET: Musterilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // GET: Musterilers/Create
        public ActionResult Create()
        {
            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi");
            return View();
        }

        // POST: Musterilers/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusteriID,KullaniciAdi,Sifre,Kullanıcı_Tipi,Adi,Soyadi,CinsiyetID,DogumTarihi,Email,TelefonNo,İl,İlce,Adres,EhliyetNo,EhliyetAlımTarihi,AcilDurumKisiAdi,AcilDurumKisiNO,AcilDurumYakınlıkDerecesi")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Musteriler.Add(musteriler);
                db.SaveChanges();
                return RedirectToAction("AnaSayfa","AnaSayfa");
            }

            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi", musteriler.CinsiyetID);
            return View(musteriler);
        }

        // GET: Musterilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi", musteriler.CinsiyetID);
            return View(musteriler);
        }

        // POST: Musterilers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusteriID,KullaniciAdi,Sifre,Kullanıcı_Tipi,Adi,Soyadi,CinsiyetID,DogumTarihi,Email,TelefonNo,İl,İlce,Adres,EhliyetNo,EhliyetAlımTarihi,AcilDurumKisiAdi,AcilDurumKisiNO,AcilDurumYakınlıkDerecesi")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi", musteriler.CinsiyetID);
            return View(musteriler);
        }

        // GET: Musterilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musterilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteriler musteriler = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
