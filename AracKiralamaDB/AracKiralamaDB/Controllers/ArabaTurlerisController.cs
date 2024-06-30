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
    public class ArabaTurlerisController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: ArabaTurleris
        public ActionResult Index()
        {
            return View(db.ArabaTurleri.ToList());
        }

        // GET: ArabaTurleris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaTurleri arabaTurleri = db.ArabaTurleri.Find(id);
            if (arabaTurleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaTurleri);
        }

        // GET: ArabaTurleris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArabaTurleris/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaTurID,ArabaTurAdi")] ArabaTurleri arabaTurleri)
        {
            if (ModelState.IsValid)
            {
                db.ArabaTurleri.Add(arabaTurleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arabaTurleri);
        }

        // GET: ArabaTurleris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaTurleri arabaTurleri = db.ArabaTurleri.Find(id);
            if (arabaTurleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaTurleri);
        }

        // POST: ArabaTurleris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArabaTurID,ArabaTurAdi")] ArabaTurleri arabaTurleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arabaTurleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arabaTurleri);
        }

        // GET: ArabaTurleris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaTurleri arabaTurleri = db.ArabaTurleri.Find(id);
            if (arabaTurleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaTurleri);
        }

        // POST: ArabaTurleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArabaTurleri arabaTurleri = db.ArabaTurleri.Find(id);
            db.ArabaTurleri.Remove(arabaTurleri);
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
