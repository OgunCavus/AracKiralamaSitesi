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
    public class KiralamalarsController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: Kiralamalars
        public ActionResult Index()
        {
            var kiralamalar = db.Kiralamalar.Include(k => k.Arabalar).Include(k => k.Musteriler);
            return View(kiralamalar.ToList());
        }
        public ActionResult MusteriIndex()
        {
            var kiralamalar = db.Kiralamalar.Include(k => k.Arabalar).Include(k => k.Musteriler);
            return View(kiralamalar.ToList());
        }

        // GET: Kiralamalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiralamalar kiralamalar = db.Kiralamalar.Find(id);
            if (kiralamalar == null)
            {
                return HttpNotFound();
            }
            return View(kiralamalar);
        }

        // GET: Kiralamalars/Create
        public ActionResult Create()
        {
            ViewBag.ArabaID = new SelectList(db.Arabalar, "ArabaID", "ArabaModelleri.ArabaModelAdi");
            ViewBag.MusteriID = new SelectList(db.Musteriler, "MusteriID", "KullaniciAdi");
            return View();
        }

        // POST: Kiralamalars/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KiraID,ArabaID,MusteriID,KiraTarih,KiraDurum")] Kiralamalar kiralamalar)
        {
            if (ModelState.IsValid)
            {
                db.Kiralamalar.Add(kiralamalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArabaID = new SelectList(db.Arabalar, "ArabaID", "ArabaModelleri.ArabaModelAdi", kiralamalar.ArabaID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "MusteriID", "KullaniciAdi", kiralamalar.MusteriID);
            return View(kiralamalar);
        }

        // GET: Kiralamalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiralamalar kiralamalar = db.Kiralamalar.Find(id);
            if (kiralamalar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArabaID = new SelectList(db.Arabalar, "ArabaID", "ArabaModelleri.ArabaModelAdi", kiralamalar.ArabaID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "MusteriID", "KullaniciAdi", kiralamalar.MusteriID);
            return View(kiralamalar);
        }
        public ActionResult MusteriEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiralamalar kiralamalar = db.Kiralamalar.Find(id);
            if (kiralamalar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArabaID = new SelectList(db.Arabalar, "ArabaID", "ArabaModelleri.ArabaModelAdi", kiralamalar.ArabaID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "MusteriID", "KullaniciAdi", kiralamalar.MusteriID);
            return View(kiralamalar);
        }

        // POST: Kiralamalars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KiraID,ArabaID,MusteriID,KiraTarih,KiraDurum")] Kiralamalar kiralamalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kiralamalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArabaID = new SelectList(db.Arabalar, "ArabaID", "ArabaModelleri.ArabaModelAdi", kiralamalar.ArabaID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "MusteriID", "KullaniciAdi", kiralamalar.MusteriID);
            return View(kiralamalar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MusteriEdit([Bind(Include = "KiraID,ArabaID,MusteriID,KiraTarih,KiraDurum")] Kiralamalar kiralamalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kiralamalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MusteriIndex");
            }
            ViewBag.ArabaID = new SelectList(db.Arabalar, "ArabaID", "ArabaModelleri.ArabaModelAdi", kiralamalar.ArabaID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "MusteriID", "KullaniciAdi", kiralamalar.MusteriID);
            return View(kiralamalar);
        }
        // GET: Kiralamalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiralamalar kiralamalar = db.Kiralamalar.Find(id);
            if (kiralamalar == null)
            {
                return HttpNotFound();
            }
            return View(kiralamalar);
        }

        // POST: Kiralamalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kiralamalar kiralamalar = db.Kiralamalar.Find(id);
            db.Kiralamalar.Remove(kiralamalar);
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
