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
    public class ArabaVitesTurlerisController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: ArabaVitesTurleris
        public ActionResult Index()
        {
            return View(db.ArabaVitesTurleri.ToList());
        }

        // GET: ArabaVitesTurleris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaVitesTurleri arabaVitesTurleri = db.ArabaVitesTurleri.Find(id);
            if (arabaVitesTurleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaVitesTurleri);
        }

        // GET: ArabaVitesTurleris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArabaVitesTurleris/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaVitesTurID,ArabaVitesTurAdi")] ArabaVitesTurleri arabaVitesTurleri)
        {
            if (ModelState.IsValid)
            {
                db.ArabaVitesTurleri.Add(arabaVitesTurleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arabaVitesTurleri);
        }

        // GET: ArabaVitesTurleris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaVitesTurleri arabaVitesTurleri = db.ArabaVitesTurleri.Find(id);
            if (arabaVitesTurleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaVitesTurleri);
        }

        // POST: ArabaVitesTurleris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArabaVitesTurID,ArabaVitesTurAdi")] ArabaVitesTurleri arabaVitesTurleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arabaVitesTurleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arabaVitesTurleri);
        }

        // GET: ArabaVitesTurleris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaVitesTurleri arabaVitesTurleri = db.ArabaVitesTurleri.Find(id);
            if (arabaVitesTurleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaVitesTurleri);
        }

        // POST: ArabaVitesTurleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArabaVitesTurleri arabaVitesTurleri = db.ArabaVitesTurleri.Find(id);
            db.ArabaVitesTurleri.Remove(arabaVitesTurleri);
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
