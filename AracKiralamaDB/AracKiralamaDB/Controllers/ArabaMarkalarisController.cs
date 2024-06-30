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
    public class ArabaMarkalarisController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: ArabaMarkalaris
        public ActionResult Index()
        {
            return View(db.ArabaMarkalari.ToList());
        }

        // GET: ArabaMarkalaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaMarkalari arabaMarkalari = db.ArabaMarkalari.Find(id);
            if (arabaMarkalari == null)
            {
                return HttpNotFound();
            }
            return View(arabaMarkalari);
        }

        // GET: ArabaMarkalaris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArabaMarkalaris/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaMarkaID,ArabaMarkaAdi")] ArabaMarkalari arabaMarkalari)
        {
            if (ModelState.IsValid)
            {
                db.ArabaMarkalari.Add(arabaMarkalari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arabaMarkalari);
        }

        // GET: ArabaMarkalaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaMarkalari arabaMarkalari = db.ArabaMarkalari.Find(id);
            if (arabaMarkalari == null)
            {
                return HttpNotFound();
            }
            return View(arabaMarkalari);
        }

        // POST: ArabaMarkalaris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArabaMarkaID,ArabaMarkaAdi")] ArabaMarkalari arabaMarkalari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arabaMarkalari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arabaMarkalari);
        }

        // GET: ArabaMarkalaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaMarkalari arabaMarkalari = db.ArabaMarkalari.Find(id);
            if (arabaMarkalari == null)
            {
                return HttpNotFound();
            }
            return View(arabaMarkalari);
        }

        // POST: ArabaMarkalaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArabaMarkalari arabaMarkalari = db.ArabaMarkalari.Find(id);
            db.ArabaMarkalari.Remove(arabaMarkalari);
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
