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
    public class ArabaModellerisController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: ArabaModelleris
        public ActionResult Index()
        {
            var arabaModelleri = db.ArabaModelleri.Include(a => a.ArabaMarkalari);
            return View(arabaModelleri.ToList());
        }

        // GET: ArabaModelleris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaModelleri arabaModelleri = db.ArabaModelleri.Find(id);
            if (arabaModelleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaModelleri);
        }

        // GET: ArabaModelleris/Create
        public ActionResult Create()
        {
            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi");
            return View();
        }

        // POST: ArabaModelleris/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaModelID,ArabaMarkaID,ArabaModelAdi")] ArabaModelleri arabaModelleri)
        {
            if (ModelState.IsValid)
            {
                db.ArabaModelleri.Add(arabaModelleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi", arabaModelleri.ArabaMarkaID);
            return View(arabaModelleri);
        }

        // GET: ArabaModelleris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaModelleri arabaModelleri = db.ArabaModelleri.Find(id);
            if (arabaModelleri == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi", arabaModelleri.ArabaMarkaID);
            return View(arabaModelleri);
        }

        // POST: ArabaModelleris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArabaModelID,ArabaMarkaID,ArabaModelAdi")] ArabaModelleri arabaModelleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arabaModelleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArabaMarkaID = new SelectList(db.ArabaMarkalari, "ArabaMarkaID", "ArabaMarkaAdi", arabaModelleri.ArabaMarkaID);
            return View(arabaModelleri);
        }

        // GET: ArabaModelleris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaModelleri arabaModelleri = db.ArabaModelleri.Find(id);
            if (arabaModelleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaModelleri);
        }

        // POST: ArabaModelleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArabaModelleri arabaModelleri = db.ArabaModelleri.Find(id);
            db.ArabaModelleri.Remove(arabaModelleri);
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
