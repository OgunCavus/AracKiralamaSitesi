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
    public class ArabalarsController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: Arabalars
        public ActionResult Index()
        {
            var arabalar = db.Arabalar.Include(a => a.ArabaMarkalari).Include(a => a.ArabaModelleri).Include(a => a.ArabaResimleri).Include(a => a.ArabaTurleri).Include(a => a.ArabaVitesTurleri);
            return View(arabalar.ToList());
        }

        // GET: Arabalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arabalar arabalar = db.Arabalar.Find(id);
            if (arabalar == null)
            {
                return HttpNotFound();
            }
            return View(arabalar);
        }

        // GET: Arabalars/Create
        public ActionResult Create()
        {
            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi");
            ViewBag.ArabaModelID = new SelectList(db.ArabaModelleri, "ArabaModelID", "ArabaModelAdi");
            ViewBag.ArabaResimID = new SelectList(db.ArabaResimleri, "ArabaResimID", "Resim");
            ViewBag.ArabaTurID = new SelectList(db.ArabaTurleri, "ArabaTurID", "ArabaTurAdi");
            ViewBag.ArabaVitesTurID = new SelectList(db.ArabaVitesTurleri, "ArabaVitesTurID", "ArabaVitesTurAdi");
            return View();
        }

        // POST: Arabalars/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaID,ArabaMarkaID,ArabaModelID,ArabaVitesTurID,ArabaTurID,ArabaResimID,Plaka,YakitTuru,Fiyat,Yıl,KoltukSayisi,BagajHacmi,MotorHacmi,MotorGucu,Klima,Navigasyon,GeriGorusKamerasi,ParkSensoru,Bluetooth,USBPortu,Sunroof")] Arabalar arabalar)
        {
            if (ModelState.IsValid)
            {
                db.Arabalar.Add(arabalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi", arabalar.ArabaMarkaID);
            ViewBag.ArabaModelID = new SelectList(db.ArabaModelleri, "ArabaModelID", "ArabaModelAdi", arabalar.ArabaModelID);
            ViewBag.ArabaResimID = new SelectList(db.ArabaResimleri, "ArabaResimID", "Resim", arabalar.ArabaResimID);
            ViewBag.ArabaTurID = new SelectList(db.ArabaTurleri, "ArabaTurID", "ArabaTurAdi", arabalar.ArabaTurID);
            ViewBag.ArabaVitesTurID = new SelectList(db.ArabaVitesTurleri, "ArabaVitesTurID", "ArabaVitesTurAdi", arabalar.ArabaVitesTurID);
            return View(arabalar);
        }

        // GET: Arabalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arabalar arabalar = db.Arabalar.Find(id);
            if (arabalar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi", arabalar.ArabaMarkaID);
            ViewBag.ArabaModelID = new SelectList(db.ArabaModelleri, "ArabaModelID", "ArabaModelAdi", arabalar.ArabaModelID);
            ViewBag.ArabaResimID = new SelectList(db.ArabaResimleri, "ArabaResimID", "Resim", arabalar.ArabaResimID);
            ViewBag.ArabaTurID = new SelectList(db.ArabaTurleri, "ArabaTurID", "ArabaTurAdi", arabalar.ArabaTurID);
            ViewBag.ArabaVitesTurID = new SelectList(db.ArabaVitesTurleri, "ArabaVitesTurID", "ArabaVitesTurAdi", arabalar.ArabaVitesTurID);
            return View(arabalar);
        }

        // POST: Arabalars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArabaID,ArabaMarkaID,ArabaModelID,ArabaVitesTurID,ArabaTurID,ArabaResimID,Plaka,YakitTuru,Fiyat,Yıl,KoltukSayisi,BagajHacmi,MotorHacmi,MotorGucu,Klima,Navigasyon,GeriGorusKamerasi,ParkSensoru,Bluetooth,USBPortu,Sunroof")] Arabalar arabalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arabalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi", arabalar.ArabaMarkaID);
            ViewBag.ArabaModelID = new SelectList(db.ArabaModelleri, "ArabaModelID", "ArabaModelAdi", arabalar.ArabaModelID);
            ViewBag.ArabaResimID = new SelectList(db.ArabaResimleri, "ArabaResimID", "Resim", arabalar.ArabaResimID);
            ViewBag.ArabaTurID = new SelectList(db.ArabaTurleri, "ArabaTurID", "ArabaTurAdi", arabalar.ArabaTurID);
            ViewBag.ArabaVitesTurID = new SelectList(db.ArabaVitesTurleri, "ArabaVitesTurID", "ArabaVitesTurAdi", arabalar.ArabaVitesTurID);
            return View(arabalar);
        }

        // GET: Arabalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arabalar arabalar = db.Arabalar.Find(id);
            if (arabalar == null)
            {
                return HttpNotFound();
            }
            return View(arabalar);
        }

        // POST: Arabalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arabalar arabalar = db.Arabalar.Find(id);
            db.Arabalar.Remove(arabalar);
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
